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
        private int hungerMeter, tiredMeter, happyMeter, stinkyMeter, loveMeter;
        private string speechBubbleValue;

        // Tryed to make these Oberservable Collections to bind to to make it more dynamicaly
        // But couldent make it work..

        //ObservableCollection<ActionItem> itemsToTakeIn = new ObservableCollection<ActionItem>(new ItemManager().ItemsToTake);
        //ObservableCollection<ActionItem> itemsToProvide = new ObservableCollection<ActionItem>(new ItemManager().ItemsToProvide);

        //public ObservableCollection<ActionItem> ItemsToTakeIn { get => itemsToTakeIn; set => itemsToTakeIn = value; }
        //public ObservableCollection<ActionItem> ItemsToProvide { get => itemsToProvide; set => itemsToProvide = value; }

        // These is the ints im binding to in my GUI
        public int HappyMeter
        {
            get { return happyMeter; }
            set
            {
                happyMeter = value;
                // Notifies the GUI that there has been a change
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

        public int LoveMeter
        {
            get { return loveMeter; }
            set
            {
                loveMeter = value;
                OnPropertyChanged();
            }
        }

        public string SpeechBubbleValue {
            get { return speechBubbleValue; }
            set
            {
                speechBubbleValue = value;
                OnPropertyChanged();
            }
        }

        public GirlfriendViewModel()
        {
            myGirlfriend = new Girlfriend("Michella");

            myGirlfriend.ValueChanged += ValueChanged;
            myGirlfriend.StateChanged += StateChanged;            
        }       

        // Handles the interaction made in the GUI And Calls
        // The respective method.In case the item is Food 
        // The Feed method is called
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
        // When the values "Hungry, Tired" and so on changes in the Girlfriend
        // This method is called to change the values in here so the progress bars
        // Will be notified that there has beed a change
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
                else if (ea.State is LoveState)
                {
                    LoveMeter = ea.Value;
                }
            }
        }
        // When the state Changes this method is called from the Girlfriend 
        // To let the SpeechBubble know there has been a state Change and 
        // It Needs to change the Content to the Value from the caller
        private void StateChanged(object sender, EventArgs e)
        {
            StateEventArgs sea = (StateEventArgs)e;
            if (sea.State != null)
            {
                SpeechBubbleValue = sea.Value;
            }

        }
    }
}
