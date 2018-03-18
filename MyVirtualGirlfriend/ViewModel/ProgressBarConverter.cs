using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
/// <summary>
/// A converter to change the color of the progress Bars
/// </summary>
namespace MyVirtualGirlfriend.ViewModel
{
    public class ProgressBarConverter : IValueConverter
    {
        // A Converting method implemented from IValueConverter
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Takes the parameter send with the call
            switch (parameter)
            {   
                case "Happy":
                    if ((int)value < 200)
                    {
                        return "red";
                    }
                    else
                    {
                        return "green";
                    }
                case "Hungry":
                    if ((int)value < 30)
                    {
                        return "red";
                    }
                    else
                    {
                        return "green";
                    }
                case "Tired":
                    if ((int)value < 70)
                    {
                        return "red";
                    }
                    else
                    {
                        return "green";
                    }
                case "Stinky":
                    if ((int)value < 50)
                    {
                        return "red";
                    }
                    else
                    {
                        return "green";
                    }
                case "Love":
                    if ((int)value < 70)
                    {
                        return "red";
                    }
                    else
                    {
                        return "green";
                    }
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
