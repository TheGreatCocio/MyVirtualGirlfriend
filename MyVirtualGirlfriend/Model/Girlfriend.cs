using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public class Girlfriend : IGirlfriendState
    {
        private string name;
        private IGirlfriendState currentState, hungryState, happyState;
        private int hungerMeter;

        public string Name { get => name; set => name = value; }
        public int HungerMeter { get => hungerMeter; private set => hungerMeter = value; }

        public Girlfriend( string name)
        {
            hungryState = new HungryState(this);
            happyState = new HappyState(this);

            HungerMeter = 100;
            currentState = happyState;
        }

        public void ChangeState(IGirlfriendState girlfriendState)
        {
            currentState = girlfriendState;
        }

        public async Task Hungry()
        {
            while (true)
            {
                while (HungerMeter > 30)
                {
                    await Task.Delay(500);
                    HungerMeter--;
                }
                ChangeState(hungryState);
            }            
        }

        public async Task Sad()
        {
            while (true)
            {

            }
        }

        public async Task Happy()
        {
            while (true)
            {
                if (HungerMeter > 30)
                {
                    ChangeState(happyState);
                }
                await Task.Delay(100);
            }            
        }

        public async Task Angry()
        {
            while (true)
            {

            }
        }

        public async Task Tired()
        {
            while (true)
            {

            }
        }
    }
}
