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
        private Girlfriend girlfriend;

        public Girlfriend Girlfriend { get => girlfriend; set => girlfriend = value; }

        public GirlfriendState(Girlfriend girlfriend)
        {
            Girlfriend = girlfriend;

            Task hunger = Task.Factory.StartNew(() => Tiredness());
            Task tiredness = Task.Factory.StartNew(() => Hunger());
        }        

        public virtual async Task Hunger()
        {            
            Debug.WriteLine("Im Hungry");
        }        

        public virtual async Task Happyness()
        {
            Debug.WriteLine("Im Happy");
        }

        public virtual async Task Angryness()
        {
            Debug.WriteLine("Im Angry");
        }

        public virtual async Task Tiredness()
        {
            Debug.WriteLine("Im Tired");
        }
    }
}
