﻿using System;
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

        }

        public override async Task Happyness()
        {
            while (true)
            {                
                Debug.WriteLine("Im Happy!");                
                await Task.Delay(1000);
            }
        }        
    }
}
