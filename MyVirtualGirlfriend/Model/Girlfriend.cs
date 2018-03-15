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

            ChangeState(happyState);
        }

        public void Feed(ActionItem item)
        {
            hungryState.Hungry += item.Value;
        }

        public void Curess(ActionItem item)
        {
            happyState.Happy += item.Value;
        }

        public void Relax(ActionItem item)
        {
            tiredState.Tired += item.Value;
        }

        public void CleanUp(ActionItem item)
        {
            stinkyState.Stinky += item.Value;
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
