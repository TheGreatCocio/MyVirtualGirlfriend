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
        
        public async Task Happyness()
        {
            while (true)
            {
                if (Girlfriend.Happy > 0)
                {
                    if (Girlfriend.Hunger >  30 && Girlfriend.Love > 70 && Girlfriend.Tired > 70 && Girlfriend.Stinky > 50)
                    {
                        Girlfriend.ChangeState(this);
                    }                    
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, 0));
                }                                               
                await Task.Delay(1000);
            }
        }        
    }
}
