using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
/// <summary>
/// The Happy State
/// </summary>
namespace MyVirtualGirlfriend.States
{
    class HappyState : GirlfriendState
    {
        public HappyState(Girlfriend girlfriend) : base(girlfriend)
        {
            // Starts a new Task to run The Happyness Method
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
                        // If all the other states is above their "Minimum" She is Happy
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, 0));
                }
                // Waits a second before running again
                await Task.Delay(1000);
            }
        }        
    }
}
