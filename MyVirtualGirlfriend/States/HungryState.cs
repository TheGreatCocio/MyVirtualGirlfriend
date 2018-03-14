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

        private int hungry = 100;

        public int Hungry {
            get { return hungry; }
            set { hungry = value; }
        }

        public async Task Hunger()
        {
            while (true)
            {
                if (hungry > 0)
                {
                    //hungry--;
                    hungry = hungry - 5;
                    if (hungry < 30)
                    {

                        Girlfriend.ChangeState(this);
                    }                    
                    
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, hungry));
                }

                await Task.Delay(1000);
            }
        }               
    }
}
