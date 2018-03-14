using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualGirlfriend.Model;
using System.Diagnostics;

namespace MyVirtualGirlfriend.States
{
    class StinkyState : GirlfriendState
    {
        public StinkyState(Girlfriend girlfriend) : base(girlfriend)
        {
            Task task = Task.Factory.StartNew(() => Stinkyness());
        }

        private int stinky = 150;

        public int Stinky
        {
            get { return stinky; }
            set { stinky = value; }
        }

        public async Task Stinkyness()
        {
            while (true)
            {
                if (stinky > 0)
                {
                    stinky = stinky - 5;
                    if (stinky > 50)
                    {
                        Girlfriend.ChangeState(this);
                        Debug.WriteLine("I Need A Shower!");
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, stinky));                    
                }                
                await Task.Delay(1000);
            }
        }
    }
}
