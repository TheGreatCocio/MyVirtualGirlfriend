using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.Model
{
    public abstract class ActionItem
    {
        public enum Type { Food, Love, Relaxing , Hygiene};

        private string name;
        private int value;
        private Type actionType;

        public ActionItem(string name, int value, Type type)
        {
            Name = name;
            Value = value;
            ActionType = type;
        }       

        public string Name { get => name; set => name = value; }
        public int Value { get => value; set => this.value = value; }
        public Type ActionType { get => actionType; set => actionType = value; }
    }
}
