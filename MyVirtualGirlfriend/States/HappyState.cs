using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;

namespace MyVirtualGirlfriend.States
{
    class HappyState : GirlfriendState
    {
        public HappyState(Girlfriend girlfriend) : base(girlfriend)
        {

        }

        public override async Task Angry()
        {
            Debug.WriteLine("Im Not Angry");
        }

        public override async Task Happy()
        {
            Debug.WriteLine("Im Really Happy!");
        }

        public override async Task Hungry()
        {
            Debug.WriteLine("Im Not Hungry");
        }

        public override async Task Sad()
        {
            Debug.WriteLine("Im Not Sad");
        }

        public override async Task Tired()
        {
            Debug.WriteLine("Im Not Tired");
        }
    }
}
