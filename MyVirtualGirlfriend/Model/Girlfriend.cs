using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public class Girlfriend : IFriend
    {
        private string name, feelings;
        private IGirlfriendState currentState, hungryState, happyState, tiredState, stinkyState, loveState;
        private int hunger, tired, happy, stinky, love;

        public string Name { get => name; set => name = value; }
        public string Feelings { get => feelings; set => feelings = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }
        // A Enhanced Get Set so fx. if hunger after she is 
        //given food is above 100 its getting set to 100
        public int Hunger
        {
            get { return hunger; }
            set { if (value >= 100) hunger = 100; else hunger = value; }
        }

        public int Tired
        {
            get { return tired; }
            set { if (value >= 200) tired = 200; else tired = value; }
        }

        public int Happy
        {
            get { return happy; }
            set { if (value >= 600) happy = 600;  else happy = value; }
        }

        public int Stinky
        {
            get { return stinky; }
            set { if (value >= 150) stinky = 150; else stinky = value; }
        }

        public int Love
        {
            get { return love; }
            set { if (value >= 150) love = 150; else love = value; }
        }

        // Girldfriend Consctructor
        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            tiredState = new TiredState(this);
            happyState = new HappyState(this);
            stinkyState = new StinkyState(this);
            loveState = new LoveState(this);

            Hunger = 100;
            Tired = 200;
            Happy = 600;
            Stinky = 150;
            Love = 150;            
        }
        // When a value changes 
        public void OnValueChanged(EventArgs e)
        {
            // Parses e into a ValueEventArg instead
            ValueEventArgs value = (ValueEventArgs)e;
            if (value.State != null)
            {
                // Looks wich state is calling the method             
                if (value.State is HungryState)
                {
                    // Ads the value of the caller to the current value
                    Hunger = Hunger + value.Value;
                    // Invokes the Value so GirlfriendViewModel knows there is a change
                    ValueChanged?.Invoke(this, new ValueEventArgs(hungryState, Hunger));
                }
                else if (value.State is TiredState)
                {
                    Tired = Tired + value.Value;
                    ValueChanged?.Invoke(this, new ValueEventArgs(tiredState, Tired));
                }
                else if (value.State is HappyState)
                {
                    Happy = Hunger + Stinky + Tired + Love + value.Value;
                    ValueChanged?.Invoke(this, new ValueEventArgs(happyState, Happy));
                }
                else if (value.State is StinkyState)
                {
                    Stinky = Stinky + value.Value;
                    ValueChanged?.Invoke(this, new ValueEventArgs(stinkyState, Stinky));
                }
                else if (value.State is LoveState)
                {
                    Love = Love + value.Value;
                    ValueChanged?.Invoke(this, new ValueEventArgs(loveState, Love));
                }
            }
        }
        // When a state changes
        public void OnStateChanged(EventArgs e)
        {
            // Parses e into a StateEventArg instead
            StateEventArgs value = (StateEventArgs)e;
            if (value.State != null)
            {
                // Looks wich state is calling the method             
                if (value.State is HappyState)
                {                    
                    // Sets the Feelings string to what she is feeling
                    Feelings = "Im Soo Happy Babe!";
                    // Invokes the Feelings String to the GirlfriendViewModel so its knows there is a change
                    StateChanged?.Invoke(this, new StateEventArgs(happyState, Feelings));
                }
                else if (value.State is HungryState)
                {
                    Feelings = "I Need Food! FEED ME!";
                    StateChanged?.Invoke(this, new StateEventArgs(hungryState, Feelings));
                }
                else if (value.State is TiredState)
                {
                    Feelings = "Im Tired! Find me a Bed!";
                    StateChanged?.Invoke(this, new StateEventArgs(tiredState, Feelings));
                }
                else if (value.State is StinkyState)
                {
                    Feelings = "I Stink! I Need a shower!";
                    StateChanged?.Invoke(this, new StateEventArgs(stinkyState, Feelings));
                }
                else if (value.State is LoveState)
                {
                    Feelings = "Love Me Stupid!";
                    StateChanged?.Invoke(this, new StateEventArgs(loveState, Feelings));
                }
            }
        }
        // Method thats called when she is given Food
        // Ads the value of the specific kind of food
        // Calls the OnValueChanged with the value
        // The same thing goes for the other methods just
        // not food.
        public void Feed(ActionItem item)
        {            
            Hunger += item.Value;            
            OnValueChanged(new ValueEventArgs(hungryState, item.Value));
        }

        public void Curess(ActionItem item)
        {
            Love += item.Value;
            OnValueChanged(new ValueEventArgs(loveState, item.Value));
        }

        public void Relax(ActionItem item)
        {
            Tired += item.Value;
            OnValueChanged(new ValueEventArgs(tiredState, item.Value));
        }

        public void CleanUp(ActionItem item)
        {
            Stinky += item.Value;
            OnValueChanged(new ValueEventArgs(stinkyState, item.Value));
        }

        // When she changes her state, CurrentState is set to the state
        // And it calls the StateChange with the new State
        public void ChangeState(IGirlfriendState girlfriendState)
        {
            CurrentState = girlfriendState;
            OnStateChanged(new StateEventArgs(CurrentState, ""));
        }

        // Public events to be Invoked
        public event EventHandler ValueChanged;
        public event EventHandler StateChanged;
    }
}
