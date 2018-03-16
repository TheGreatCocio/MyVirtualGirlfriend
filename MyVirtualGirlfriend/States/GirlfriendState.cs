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
        }
        
    }
}
