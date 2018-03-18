using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using System.Diagnostics;
/// <summary>
/// The Stinky State
/// </summary>
namespace MyVirtualGirlfriend.States
{
    class StinkyState : GirlfriendState
    {
        public StinkyState(Girlfriend girlfriend) : base(girlfriend)
        {
            // Starts a new Task to run The Stinkyness Method
            Task task = Task.Factory.StartNew(() => Stinkyness());
        }
        // stinkyDown is set to what Stinky should be decreased with
        private int stinkyDown = -3;
        
        public async Task Stinkyness()
        {
            while (true)
            {
                if (Girlfriend.Stinky > 0)
                {
                    if (Girlfriend.Stinky < 50)
                    {
                        // If Girlfriend.Stinky is below 50 she changes state to Stinky
                        Girlfriend.ChangeState(this);
                    }
                    // Calls the value Changed method with the decreaser
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, stinkyDown));                    
                }          
                // Waits a second before running again
                await Task.Delay(1000);
            }
        }
    }
}
