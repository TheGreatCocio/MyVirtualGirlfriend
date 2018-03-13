using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriend.States;
using MyVirtualGirlfriendd.Model;
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

        public GirlfriendViewModel()
        {
            myGirlfriend = new Girlfriend("Michella");

            myGirlfriend.ValueChanged += ValueChanged;
            
            Task printer = Task.Factory.StartNew(() => Printer());
        }

        

        public async Task Printer()
        {
            while (true)
            {
                Debug.WriteLine("Something");
                await Task.Delay(500);
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            ValueEventArgs ea = (ValueEventArgs)e;
            if (ea.State != null)
            {
                Debug.WriteLine("VAL CHA +" + ea.State.GetType());
                if (ea.State is HungryState)
                {
                    HungerMeter = ea.Value;
                }
                else if (ea.State is TiredState)
                {
                    TiredMeter = ea.Value;
                }
            }
        }
    }
}
