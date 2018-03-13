using MyVirtualGirlfriend.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.States
{
    abstract class GirlfriendState : IGirlfriendState
    {
        private int hungerMeter;
        private Girlfriend girlfriend;

        public Girlfriend Girlfriend { get => girlfriend; set => girlfriend = value; }

        public GirlfriendState(Girlfriend girlfriend)
        {
            Girlfriend = girlfriend;
            hungerMeter = 100;
        }

        public virtual async Task Hungry()
        {            
            Debug.WriteLine("Im Hungry");
        }

        public virtual async Task Sad()
        {
            Debug.WriteLine("Im Sad");
        }

        public virtual async Task Happy()
        {
            Debug.WriteLine("Im Happy");
        }

        public virtual async Task Angry()
        {
            Debug.WriteLine("Im Angry");
        }

        public virtual async Task Tired()
        {
            Debug.WriteLine("Im Tired");
        }
    }
}
