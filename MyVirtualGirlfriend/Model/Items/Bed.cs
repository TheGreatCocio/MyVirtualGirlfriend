using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model.Items
{
    class Bed : ActionItem
    {
        public Bed() : base("sleep", 75, Type.Relaxing)
        {
        }
    }
}
