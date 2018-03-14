using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriend.States;
using System;
using System.Collections.Generic;
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
        private int hungerMeter;
        private int tiredMeter;
        private int happyMeter;
        private int stinkyMeter;

        public int HappyMeter
        {
            get { return happyMeter; }
            set
            {
                happyMeter = value;
                //OnPropertyChanged();
            }
        }

        public int HungerMeter
        {
            get { return hungerMeter; }
            set
            {
                hungerMeter = value;
                //OnPropertyChanged();
            }
        }

        public int TiredMeter
        {
            get { return tiredMeter; }
            set
            {
                tiredMeter = value;
                //OnPropertyChanged();
            }
        }

        public int StinkyMeter
        {
            get { return stinkyMeter; }
            set
            {
                stinkyMeter = value;
                //OnPropertyChanged();
            }
        }

        public GirlfriendViewModel()
        {
            myGirlfriend = new Girlfriend("Michella");

            myGirlfriend.ValueChanged += ValueChanged;
                        
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
