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
        private HungryState hungry;
        private TiredState tired;

        internal HungryState Hungry { get => hungry; private set => hungry = value; }
        internal TiredState Tired { get => tired; private set => tired = value; }

        public HappyState(Girlfriend girlfriend, HungryState hungry, TiredState tired) : base(girlfriend)
        {
            Tired = tired;
            Hungry = hungry;
            Task task = Task.Factory.StartNew(() => Happyness());
        }
        
        private int happy;

        public int Happy { get { return happy; } }
        
        public async Task Happyness()
        {
            while (true)
            {
                happy = Hungry.Hungry + Tired.Tired;
                if (happy > 0)
                {
                    if (happy > 150)
                    {
                        Debug.WriteLine("Im Happy!");
                        Girlfriend.ChangeState(this);
                    }
                    Girlfriend.OnValueChanged(new ValueEventArgs(this, happy));
                }                                               
                await Task.Delay(1000);
            }
        }        
    }
}
