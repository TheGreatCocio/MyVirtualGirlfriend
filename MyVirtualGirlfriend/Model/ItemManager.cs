using MyVirtualGirlfriend.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public class ItemManager
    {
        private List<ActionItem> itemsToTake = new List<ActionItem>();
        private List<ActionItem> itemsToProvide = new List<ActionItem>();

        public ItemManager()
        {
            ItemsToTake.Add(new Salad());
            ItemsToTake.Add(new Burger());
            ItemsToTake.Add(new Water());

            ItemsToProvide.Add(new Kiss());
            ItemsToProvide.Add(new Tickle());
            ItemsToProvide.Add(new Shower());
            ItemsToProvide.Add(new Bed());
        }

        public List<ActionItem> ItemsToProvide { get => itemsToProvide; set => itemsToProvide = value; }
        public List<ActionItem> ItemsToTake { get => itemsToTake; set => itemsToTake = value; }
    }
}
