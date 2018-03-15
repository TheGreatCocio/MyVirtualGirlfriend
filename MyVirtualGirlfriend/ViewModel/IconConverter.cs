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
            if (parameter.Equals("Heart"))
            {
                if ((int)value < 70)
                {
                    return "Assets/broken-heart.png";
                }
                else
                {
                    return "Assets/love.png";
                }
            }
            else if (parameter.Equals("Happy"))
            {
                if ((int)value < 200)
                {
                    return "Assets/angry-icon.png";
                }
                else
                {
                    return "Assets/happy-icon.png";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
