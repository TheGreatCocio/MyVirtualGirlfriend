using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriendd.Model;

namespace MyVirtualGirlfriend.States
{
    class TiredState : GirlfriendState
    {
        public TiredState(Girlfriend girlfriend) : base(girlfriend)
        {
        }

        private int tiredMeter = 200;

        public override async Task Tiredness()
        {
            while (true)
            {
                if (tiredMeter > 0)
                {
                    tiredMeter--;
                    if (tiredMeter < 30)
                    {
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, tiredMeter));
                }
                await Task.Delay(1000);
            }
        }
    }
}
