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

namespace MyVirtualGirlfriend.ViewModel
{
    public class ActionItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ActionItem item)
            {
                return "Assets/" + item.Name + ".png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Image image)
            {
                BitmapImage bitmap = (BitmapImage)image.Source;
                Uri uri = bitmap?.UriSource;
                string path = uri?.AbsolutePath;

                switch (path)
                {
                    case "/assets/salad.png": return new Salad();
                    case "/assets/burger.png": return new Burger();
                    case "/assets/water.png": return new Water();
                    case "/assets/sleep.png": return new Bed();
                    case "/assets/soap.png": return new Shower();
                    default:
                        break;
                }
            }
            return null;
        }
    }
}
