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
        private IGirlfriendState currentState, hungryState, happyState;

        public string Name { get => name; set => name = value; }
        public IGirlfriendState CurrentState { get => currentState; set => currentState = value; }

        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            happyState = new HappyState(this);

            CurrentState = hungryState;
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
