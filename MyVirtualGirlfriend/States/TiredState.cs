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

        private int tired = 200;

        public int Tired { get { return tired; } }

        public async Task Tiredness()
        {
            while (true)
            {
                if (tired > 0)
                {
                    //tired--;
                    tired = tired - 5;
                    if (tired < 30)
                    {
                        Girlfriend.ChangeState(this);
                        Debug.WriteLine("Im Soooo Tired!");
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, tired));
                }
                await Task.Delay(1000);
            }
        }
    }
}
