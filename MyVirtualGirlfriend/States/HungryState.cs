using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriendd.Model;

namespace MyVirtualGirlfriend.States
{
    class HungryState : GirlfriendState
    {
        public HungryState(Girlfriend girlfriend) : base(girlfriend)
        {

        }

        private int hungerMeter = 100;

        public override async Task Hunger()
        {
            while (true)
            {
                if (hungerMeter > 0)
                {
                    hungerMeter--;

                    if (hungerMeter < 30)
                    {

                        Girlfriend.ChangeState(this);
                    }                    
                    
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, hungerMeter));
                }

                await Task.Delay(1000);
            }
        }               
    }
}
