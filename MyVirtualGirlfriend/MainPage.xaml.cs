using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriend.States;
using MyVirtualGirlfriend.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyVirtualGirlfriend
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }        

        private void Michella_DragOver(object sender, DragEventArgs e)
        {
            // Allows a item to be dragged over another image
            e.AcceptedOperation = DataPackageOperation.Move;
        }

        private void Michella_Drop(object sender, DragEventArgs e)
        {
            // Takes the propperties send with the item and parse it to a UIElement
            UIElement element = (UIElement)e.DataView.Properties["type"];
            
            ActionItemConverter converter = new ActionItemConverter();
            // Takes the item and converts it back to a ActionItem
            ActionItem item = (ActionItem)converter.ConvertBack(element, null, null, null);
            // Takes the current GirlfriendViewModel instance from the DataContext
            GirlfriendViewModel girlfriend = (GirlfriendViewModel)MainWindow.DataContext;
            // Pass the item to the HandleIteraction Method in the GirldfriendViewModel
            girlfriend.HandleInteraction(item);            
        }

        private void Item_Dragstarting(UIElement sender, DragStartingEventArgs args)
        {
            // When an item is beginning to be dragged it 
            // Sends its propperties with it
            args.Data.Properties.Add("type", sender);
        }
    }
}
