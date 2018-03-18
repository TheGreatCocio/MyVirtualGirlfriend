using MyVirtualGirlfriend.Model;
using MyVirtualGirlfriend.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
/// <summary>
/// A converter to return the path to the correct image
/// And Convert Images back to the Path
/// </summary>
namespace MyVirtualGirlfriend.ViewModel
{
    public class ActionItemConverter : IValueConverter
    {
        // A Converting method implemented from IValueConverter
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // If the Value is a ActionItem
            if (value is ActionItem item)
            {
                // Returns the path to the image
                return "Assets/" + item.Name + ".png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Image image)
            {
                // Converts the Image to a BitMap Image
                BitmapImage bitmap = (BitmapImage)image.Source;
                // Gets the Uri from the BitMap
                Uri uri = bitmap?.UriSource;
                // Gets the AbsolutePath from the Uri
                string path = uri?.AbsolutePath;
                // Returns the correct ActionItem based in the path
                switch (path)
                {
                    case "/Assets/salad.png": return new Salad();
                    case "/Assets/burger.png": return new Burger();
                    case "/Assets/water.png": return new Water();
                    case "/Assets/sleep.png": return new Bed();
                    case "/Assets/soap.png": return new Shower();
                    case "/Assets/kiss.png": return new Kiss();
                    case "/Assets/iloveyou.png": return new ILoveYou();
                    case "/Assets/tickle.png": return new Tickle();
                    default:
                        break;
                }
            }
            return null;
        }
    }
}
