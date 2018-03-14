using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MyVirtualGirlfriend.ViewModel
{
    public class IconConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value < 150)
            {
                return "Assets/angry-icon.png";
            }
            else
            {
                return "Assets/happy-icon.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
