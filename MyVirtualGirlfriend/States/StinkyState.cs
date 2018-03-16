using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using System.Diagnostics;

namespace MyVirtualGirlfriend.States
{
    class StinkyState : GirlfriendState
    {
        public StinkyState(Girlfriend girlfriend) : base(girlfriend)
        {
            Task task = Task.Factory.StartNew(() => Stinkyness());
        }

        private int stinkyDown = -2;
        
        public async Task Stinkyness()
        {
            while (true)
            {
                if (Girlfriend.Stinky > 0)
                {
                    if (Girlfriend.Stinky < 50)
                    {
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, stinkyDown));                    
                }                
                await Task.Delay(1000);
            }
        }
    }
}
