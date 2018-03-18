using MyVirtualGirlfriend.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The Love State
/// </summary>
namespace MyVirtualGirlfriend.States
{
    class LoveState : GirlfriendState
    {
        public LoveState(Girlfriend girlfriend) : base(girlfriend)
        {
            // Starts a new Task to run The Love Method
            Task task = Task.Factory.StartNew(() => Love());
        }
        // loveDown is set to what Love should be decreased with
        private int loveDown = -3;

        public async Task Love()
        {
            while (true)
            {
                if (Girlfriend.Love > 0)
                {
                    if (Girlfriend.Love < 70)
                    {
                        // If Girlfriend.Love is below 70 she changes state to Love
                        Girlfriend.ChangeState(this);
                    }
                    // Calls the value Changed method with the decreaser
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, loveDown));
                }
                // Waits a second before running again
                await Task.Delay(1000);
            }
        }
    }
}
