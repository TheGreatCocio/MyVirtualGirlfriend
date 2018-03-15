using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;

namespace MyVirtualGirlfriend.States
{
    class HappyState : GirlfriendState
    {
        public HappyState(Girlfriend girlfriend) : base(girlfriend)
        {
            Task task = Task.Factory.StartNew(() => Happyness());
        }
        
        private int happyDown = -1;        
        
        public async Task Happyness()
        {
            while (true)
            {
                if (Girlfriend.Happy > 0)
                {
                    if (Girlfriend.Happy > 200)
                    {
                        Debug.WriteLine("Im Happy!");
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, happyDown));
                }                                               
                await Task.Delay(1000);
            }
        }        
    }
}
