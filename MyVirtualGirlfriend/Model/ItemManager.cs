using MyVirtualGirlfriend.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Method for managing Action Items
/// </summary>
namespace MyVirtualGirlfriend.Model
{
    // Makes 2 Lists with all the Action Items i have so that i can
    // Use them in a Observalble Collection I the VievModel
    public class ItemManager
    {
        private List<ActionItem> itemsToGive = new List<ActionItem>();
        private List<ActionItem> itemsToProvide = new List<ActionItem>();

        public ItemManager()
        {
            ItemsToGive.Add(new Salad());
            ItemsToGive.Add(new Burger());
            ItemsToGive.Add(new Water());
            ItemsToGive.Add(new Kiss());

            ItemsToProvide.Add(new Tickle());
            ItemsToProvide.Add(new ILoveYou());
            ItemsToProvide.Add(new Shower());
            ItemsToProvide.Add(new Bed());
        }

        public List<ActionItem> ItemsToProvide { get => itemsToProvide; set => itemsToProvide = value; }
        public List<ActionItem> ItemsToGive { get => itemsToGive; set => itemsToGive = value; }
    }
}
