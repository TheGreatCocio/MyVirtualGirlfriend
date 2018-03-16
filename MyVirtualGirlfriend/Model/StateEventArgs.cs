
using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public class StateEventArgs : EventArgs
    {

        IGirlfriendState state;
        string value;

        public IGirlfriendState State { get => state; set => state = value; }
        public string Value { get => value; set => this.value = value; }

        public StateEventArgs(IGirlfriendState state, string value)
        {
            State = state;
            Value = value;
        }

    }
}
