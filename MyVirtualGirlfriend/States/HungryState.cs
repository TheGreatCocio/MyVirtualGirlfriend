using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
/// <summary>
/// The Hungry State
/// </summary>
namespace MyVirtualGirlfriend.States
{
    class HungryState : GirlfriendState
    {
        public HungryState(Girlfriend girlfriend) : base(girlfriend)
        {
            // Starts a new Task to run The Love Method
            Task task = Task.Factory.StartNew(() => Hunger());           
        }
        // loveDown is set to what Love should be decreased with
        private int hungryDown = -3;       

        public async Task Hunger()
        {
            while (true)
            {
                if (Girlfriend.Hunger > 0)
                {
                    if (Girlfriend.Hunger < 30)
                    {
                        // If Girlfriend.Love is below 30 she changes state to Love
                        Girlfriend.ChangeState(this);
                    }
                    // Calls the value Changed method with the decreaser
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, hungryDown));
                }
                // Waits a second before running again
                await Task.Delay(1000);
            }
        }               
    }
}
