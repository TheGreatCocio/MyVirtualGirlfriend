
using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// A New EventArgs Method
/// </summary>
namespace MyVirtualGirlfriend.Model
{
    public class ValueEventArgs : EventArgs
    {
        IGirlfriendState state;
        int value;

        public IGirlfriendState State { get => state; set => state = value; }
        public int Value { get => value; set => this.value = value; }

        public ValueEventArgs(IGirlfriendState state, int value)
        {
            State = state;
            Value = value;
        }

    }
}
