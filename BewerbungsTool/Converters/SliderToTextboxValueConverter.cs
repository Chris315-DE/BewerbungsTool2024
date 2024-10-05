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
                    return "Anfänger";
                case "2":
                    return "Anfänger+";
                case "3":
                    return "Grundkenntnisse";
                case "4":
                    return "Fortgeschritten";
                case "5":
                    return "Kompetent";
                case "6":
                    return "Geübt";
                case "7":
                    return "Erfahren";
                case "8":
                    return "Versiert";
                case "9":
                    return "Profi";
                case "10":
                    return "Experte";
                default:
                    return "Unwissend";

            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
