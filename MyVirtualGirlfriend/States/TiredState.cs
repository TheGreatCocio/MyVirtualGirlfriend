using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
/// <summary>
/// The Tired State
/// </summary>
namespace MyVirtualGirlfriend.States
{
    class TiredState : GirlfriendState
    {
        public TiredState(Girlfriend girlfriend) : base(girlfriend)
        {
            // Starts a new Task to run The Tiredness Method
            Task task = Task.Factory.StartNew(() => Tiredness());
        }
        // tiredDown is set to what Tired should be decreased with
        private int tiredDown = -3;        

        public async Task Tiredness()
        {
            while (true)
            {
                if (Girlfriend.Tired > 0)
                {
                    if (Girlfriend.Tired < 70)
                    {
                        // If Girlfriend.Tired is below 70 she changes state to Tired
                        Girlfriend.ChangeState(this);
                    }
                    // Calls the value Changed method with the decreaser
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, tiredDown));
                }
                // Waits a second before running again
                await Task.Delay(1000);
            }
        }
    }
}
