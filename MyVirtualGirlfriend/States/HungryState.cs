using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;

namespace MyVirtualGirlfriend.States
{
    class HungryState : GirlfriendState
    {
        public HungryState(Girlfriend girlfriend) : base(girlfriend)
        {

        }

        public override async Task Hungry()
        {
            Debug.WriteLine("I NEED FOOD!");
        }

        public override async Task Angry()
        {
            Debug.WriteLine("Im Angry Because I Need Food!");
        }

        public override async Task Happy()
        {
            Debug.WriteLine("Im not happy because i need food!");
        }        
    }
}
