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
        private IGirlfriendState currentState;
        private HungryState hungryState;
        private HappyState happyState;
        private TiredState tiredState;
        private StinkyState stinkyState;

        public string Name { get => name; set => name = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }

        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            tiredState = new TiredState(this);
            happyState = new HappyState(this, hungryState, tiredState);
            stinkyState = new StinkyState(this);

            CurrentState = happyState;
        }

        public void Feed()
        {
            hungryState.Hungry += 50;
        }

        public void Kiss()
        {
            happyState.Happy += 5;
        }

        public void Sleep()
        {
            tiredState.Tired += 150;
        }

        public void Shower()
        {
            stinkyState.Stinky += 100;
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
