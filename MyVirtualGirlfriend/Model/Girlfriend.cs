using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public class Girlfriend
    {
        private string name, feelings;
        private IGirlfriendState currentState, hungryState, happyState, tiredState, stinkyState, loveState;
        private int hunger, tired, happy, stinky, love;

        public string Name { get => name; set => name = value; }
        public string Feelings { get => feelings; set => feelings = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }

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

            //ChangeState(happyState);
        }
        public void OnValueChanged(EventArgs e)
        {
            ValueEventArgs value = (ValueEventArgs)e;
            if (value.State != null)
            {                
                if (value.State is HungryState)
                {
                    Hunger = Hunger + value.Value;
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

        public void OnStateChanged(EventArgs e)
        {
            StateEventArgs value = (StateEventArgs)e;
            if (value.State != null)
            {
                if (value.State is HappyState)
                {                    
                    Feelings = "Im Soo Happy Babe!";
                    StateChanged?.Invoke(this, new StateEventArgs(happyState, Feelings));
                }
                else if (value.State is HungryState)
                {
                    Feelings = "Im Need Food!";
                    StateChanged?.Invoke(this, new StateEventArgs(hungryState, Feelings));
                }
                else if (value.State is TiredState)
                {
                    Feelings = "Im Need Sleep!";
                    StateChanged?.Invoke(this, new StateEventArgs(tiredState, Feelings));
                }
                else if (value.State is StinkyState)
                {
                    Feelings = "Im Stink! I Need a shower!";
                    StateChanged?.Invoke(this, new StateEventArgs(stinkyState, Feelings));
                }
                else if (value.State is LoveState)
                {
                    Feelings = "Love Me Stupid!";
                    StateChanged?.Invoke(this, new StateEventArgs(loveState, Feelings));
                }
                //switch (value.State)
                //{
                //    case HappyState state: Feelings = "Im Soo Happy Babe!";
                //        StateChanged?.Invoke(this, new StateEventArgs(happyState, Feelings)); break;
                //    case HungryState state: Feelings = "Im Need Food!";
                //        StateChanged?.Invoke(this, new StateEventArgs(hungryState, Feelings)); break;
                //    case TiredState state: Feelings = "Im Need Sleep!";
                //        StateChanged?.Invoke(this, new StateEventArgs(tiredState, Feelings)); break;
                //    case StinkyState state: Feelings = "Im Stink! I Need a shower!";
                //        StateChanged?.Invoke(this, new StateEventArgs(stinkyState, Feelings)); break;
                //    case LoveState state: Feelings = "Love Me Stupid!";
                //        StateChanged?.Invoke(this, new StateEventArgs(loveState, Feelings)); break;
                //    default:
                //        break;
                //}
            }
        }

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

        public void ChangeState(IGirlfriendState girlfriendState)
        {
            CurrentState = girlfriendState;
            OnStateChanged(new StateEventArgs(CurrentState, ""));
        }

        public event EventHandler ValueChanged;
        public event EventHandler StateChanged;
    }
}
