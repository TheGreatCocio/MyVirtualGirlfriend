using MyVirtualGirlfriend.Model;
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
    public class GirlfriendViewModel : INotifyPropertyChanged
    {
        private Girlfriend myGirlfriend;

        public Girlfriend MyGirlfriend {
            get => myGirlfriend;
            set
            {
                myGirlfriend = value;
                OnPropertyChanged("MyGirlfriend");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;        
        
        public GirlfriendViewModel()
        {
            myGirlfriend = new Girlfriend("Michella");

            Task happy = Task.Factory.StartNew(() => myGirlfriend.Happy());
            Task hunger = Task.Factory.StartNew(() => myGirlfriend.Hungry());
            Task printer = Task.Factory.StartNew(() => Printer());
        }

        public async Task Printer()
        {
            while (true)
            {
                Debug.WriteLine(MyGirlfriend.HungerMeter);
                await Task.Delay(500);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
