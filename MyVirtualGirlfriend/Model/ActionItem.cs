using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// ActionItem Super Class
/// </summary>
namespace MyVirtualGirlfriend.Model
{
    public abstract class ActionItem
    {
        // A Enum for the different types of Interactions for her
        public enum Type { Food, Love, Relaxing , Hygiene};

        private string name;
        private int value;
        private Type actionType;

        // ActionItem constructor that every SubClass puts value into
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
