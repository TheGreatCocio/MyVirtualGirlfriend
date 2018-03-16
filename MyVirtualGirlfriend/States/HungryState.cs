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
            Task task = Task.Factory.StartNew(() => Hunger());           
        }

        private int hungryDown = -2;       

        public async Task Hunger()
        {
            while (true)
            {
                if (Girlfriend.Hunger > 0)
                {
                    if (Girlfriend.Hunger < 30)
                    {
                        Girlfriend.ChangeState(this);
                    }                                        
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, hungryDown));
                }
                await Task.Delay(1000);
            }
        }               
    }
}
