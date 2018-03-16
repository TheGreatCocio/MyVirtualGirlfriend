using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;

namespace MyVirtualGirlfriend.States
{
    class TiredState : GirlfriendState
    {
        public TiredState(Girlfriend girlfriend) : base(girlfriend)
        {
            Task task = Task.Factory.StartNew(() => Tiredness());
        }

        private int tiredDown = -2;        

        public async Task Tiredness()
        {
            while (true)
            {
                if (Girlfriend.Tired > 0)
                {
                    if (Girlfriend.Tired < 70)
                    {
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, tiredDown));
                }
                await Task.Delay(1000);
            }
        }
    }
}
