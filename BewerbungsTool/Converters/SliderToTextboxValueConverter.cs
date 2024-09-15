using System.Globalization;
using System.Windows.Data;

namespace BewerbungsTool.Converters
{
    public class SliderToTextboxValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            var inputValue = (string)value;

            switch (inputValue)
            {
                case "1":
                    return "Garnicht";
                case "2":
                    return "Sehr schlecht";
                case "3":
                    return "schlecht";
                case "4":
                    return "Naja";
                case "5":
                    return "OK";
                case "6":
                    return "Es geht";
                case "7":
                    return "Kann ich";
                case "8":
                    return "Kann ich gut";
                case "9":
                    return "Kann ich sehr gut";
                case "10":
                    return "Profi";
                default:
                    return "NV";

            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
