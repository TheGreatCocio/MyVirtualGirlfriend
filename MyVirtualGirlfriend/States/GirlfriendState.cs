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
        private IGirlfriendState hungerState, tiredState, stinkyState, happyState;

        public Girlfriend Girlfriend { get => girlfriend; set => girlfriend = value; }

        public GirlfriendState(Girlfriend girlfriend)
        {
            Girlfriend = girlfriend;            
        }                

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public void PutToBed()
        {
            throw new NotImplementedException();
        }

        public void Tickle()
        {
            throw new NotImplementedException();
        }

        public void Kiss()
        {
            throw new NotImplementedException();
        }
    }
}
