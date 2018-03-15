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
            e.AcceptedOperation = DataPackageOperation.Move;
        }

        private void Michella_Drop(object sender, DragEventArgs e)
        {
            UIElement element = (UIElement)e.DataView.Properties["type"];

            ActionItemConverter converter = new ActionItemConverter();
            ActionItem item = (ActionItem)converter.ConvertBack(element, null, null, null);

            GirlfriendViewModel girlfriend = (GirlfriendViewModel)MainWindow.DataContext;

            girlfriend.HandleInteraction(item);            
        }

        private void Item_Dragstarting(UIElement sender, DragStartingEventArgs args)
        {
            args.Data.Properties.Add("type", sender);
        }
    }
}
