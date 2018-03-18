using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Interface for a new Friend
/// </summary>
namespace MyVirtualGirlfriend.Model
{
    public interface IFriend
    {
        string Name { get; set; }

        int Happy { get; set; }
        int Hunger { get; set; }
        int Tired { get; set; }
        int Stinky { get; set; }
        int Love { get; set; }

        void Feed(ActionItem item);

        void Curess(ActionItem item);

        void Relax(ActionItem item);

        void CleanUp(ActionItem item);
    }
}
