using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using System.Diagnostics;

namespace MyVirtualGirlfriend.States
{
    class AngryState : GirlfriendState
    {
        public AngryState(Girlfriend girlfriend) : base(girlfriend)
        {
        }

        public override async Task Angryness()
        {
            while (true)
            {
                Debug.WriteLine("Im So Angry!");
                await Task.Delay(1000);
            }
        }
    }
}
