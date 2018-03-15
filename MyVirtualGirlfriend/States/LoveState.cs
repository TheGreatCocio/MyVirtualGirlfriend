using MyVirtualGirlfriend.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.States
{
    class LoveState : GirlfriendState
    {
        public LoveState(Girlfriend girlfriend) : base(girlfriend)
        {
            Task task = Task.Factory.StartNew(() => Love());
        }

        private int loveDown = -1;

        public async Task Love()
        {
            while (true)
            {
                if (Girlfriend.Love > 0)
                {
                    if (Girlfriend.Love > 60)
                    {
                        Debug.WriteLine("I Love You!");
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, loveDown));
                }
                await Task.Delay(1000);
            }
        }
    }
}
