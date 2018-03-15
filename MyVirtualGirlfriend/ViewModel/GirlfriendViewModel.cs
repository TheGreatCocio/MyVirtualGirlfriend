using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualGirlfriend.ViewModel
{
    public class GirlfriendViewModel : ViewModelBase
    {
        
        private Girlfriend myGirlfriend;
        private int hungerMeter, tiredMeter, happyMeter, stinkyMeter;
        ObservableCollection<ActionItem> itemsToTakeIn = new ObservableCollection<ActionItem>(new ItemManager().ItemsToTake);
        ObservableCollection<ActionItem> itemsToProvide = new ObservableCollection<ActionItem>(new ItemManager().ItemsToProvide);

        public ObservableCollection<ActionItem> ItemsToTakeIn { get => itemsToTakeIn; set => itemsToTakeIn = value; }
        public ObservableCollection<ActionItem> ItemsToProvide { get => itemsToProvide; set => itemsToProvide = value; }

        public int HappyMeter
        {
            get { return happyMeter; }
            set
            {
                happyMeter = value;
                OnPropertyChanged();
            }
        }

        public int HungerMeter
        {
            get { return hungerMeter; }
            set
            {
                hungerMeter = value;
                OnPropertyChanged();
            }
        }

        public int TiredMeter
        {
            get { return tiredMeter; }
            set
            {
                tiredMeter = value;
                OnPropertyChanged();
            }
        }

        public int StinkyMeter
        {
            get { return stinkyMeter; }
            set
            {
                stinkyMeter = value;
                OnPropertyChanged();
            }
        }

        public GirlfriendViewModel()
        {
            myGirlfriend = new Girlfriend("Michella");

            myGirlfriend.ValueChanged += ValueChanged;
                        
        }       

        public void HandleInteraction(ActionItem item)
        {
            switch (item.ActionType)
            {
                case ActionItem.Type.Food:
                    myGirlfriend.Feed(item);
                    break;
                case ActionItem.Type.Love:
                    myGirlfriend.Curess(item);
                    break;
                case ActionItem.Type.Relaxing:
                    myGirlfriend.Relax(item);
                    break;
                case ActionItem.Type.Hygiene:
                    myGirlfriend.CleanUp(item);
                    break;
                default:
                    break;
            }
        }        

        private void ValueChanged(object sender, EventArgs e)
        {
            ValueEventArgs ea = (ValueEventArgs)e;
            if (ea.State != null)
            {
                if (ea.State is HungryState)
                {
                    HungerMeter = ea.Value;
                }
                else if (ea.State is TiredState)
                {
                    TiredMeter = ea.Value;
                }
                else if (ea.State is HappyState)
                {
                    HappyMeter = ea.Value;
                }
                else if (ea.State is StinkyState)
                {
                    StinkyMeter = ea.Value;
                }
            }
        }
    }
}
