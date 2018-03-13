using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.States
{
    public interface IGirlfriendState
    {
        Task Hungry();

        Task Sad();

        Task Happy();

        Task Angry();

        Task Tired();
    }
}
