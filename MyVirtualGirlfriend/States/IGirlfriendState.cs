﻿using MyVirtualGirlfriend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.States
{
    public interface IGirlfriendState
    {
        Girlfriend Girlfriend {get; set;}
    }
}
