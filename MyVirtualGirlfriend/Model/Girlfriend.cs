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
        private string name;
        private IGirlfriendState currentState, hungryState, happyState, tiredState, stinkyState, loveState;
        private int hunger, tired, happy, stinky, love;

        public string Name { get => name; set => name = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }
        public int Hunger { get => hunger; set => hunger = value; }
        public int Tired { get => tired; set => tired = value; }
        public int Happy { get => happy; set => happy = value; }
        public int Stinky { get => stinky; set => stinky = value; }
        public int Love { get => love; set => love = value; }

        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            tiredState = new TiredState(this);
            happyState = new HappyState(this);
            stinkyState = new StinkyState(this);
            loveState = new LoveState(this);

            Hunger = 100;
            Tired = 200;
            Happy = 450;
            Stinky = 150;
            Love = 150;

            ChangeState(happyState);
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
        }

        public event EventHandler ValueChanged;

        public void OnValueChanged(EventArgs e)
        {
            ValueEventArgs value = (ValueEventArgs)e;
            if (value.State != null)
            {
                
                if (value.State is HungryState)
                {

                    Hunger = Hunger + value.Value;
                    if (Hunger >= 100)
                        Hunger = 100;

                    ValueChanged?.Invoke(this, new ValueEventArgs(hungryState, Hunger));
                }
                else if (value.State is TiredState)
                {
                    Tired = Tired + value.Value;
                    if (Tired >= 200)
                    {
                        Tired = 200;

                    }
                    ValueChanged?.Invoke(this, new ValueEventArgs(tiredState, Tired));
                }
                else if (value.State is HappyState)
                {
                    Happy = Hunger + Stinky + Tired + value.Value;
                    if (Happy >= 450)
                    {
                        Happy = 450;
                    }
                    ValueChanged?.Invoke(this, new ValueEventArgs(happyState, Happy));
                }
                else if (value.State is StinkyState)
                {
                    Stinky = Stinky + value.Value;
                    if (Stinky >= 150)
                    {
                        Stinky = 150;
                    }
                    ValueChanged?.Invoke(this, new ValueEventArgs(stinkyState, Stinky));
                }
                else if (value.State is LoveState)
                {
                    Love = Love + value.Value;
                    if (Love >= 150)
                    {
                        Love = 150;
                    }
                    ValueChanged?.Invoke(this, new ValueEventArgs(loveState, Love));
                }
            }
        }
    }
}
