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
        private int happy, hungry, tired, stinky;
        private IGirlfriendState currentState, hungryState, happyState, tiredState, stinkyState;

        public string Name { get => name; set => name = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }

        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            tiredState = new TiredState(this);
            happyState = new HappyState(this, (HungryState)hungryState, (TiredState)tiredState);
            stinkyState = new StinkyState(this);           

            CurrentState = happyState;
        }        

        public void ChangeState(IGirlfriendState girlfriendState)
        {
            CurrentState = girlfriendState;
        }

        public event EventHandler ValueChanged;

        public void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
