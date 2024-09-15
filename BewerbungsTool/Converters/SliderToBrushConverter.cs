using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BewerbungsTool.Converters
{
    public class SliderToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (string)value;

            switch (inputValue)
            {
                case "1":
                    return Brushes.Red;
                case "2":
                    return Brushes.Red;
                case "3":
                    return Brushes.OrangeRed;
                case "4":
                    return Brushes.Orange;
                case "5":
                    return Brushes.Yellow;
                case "6":
                    return Brushes.Yellow;
                case "7":
                    return Brushes.YellowGreen;
                case "8":
                    return Brushes.Green;
                case "9":
                    return Brushes.Green; 
                case "10":
                    return Brushes.Green;
                default:
                    return Brushes.Red;

            }







        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
