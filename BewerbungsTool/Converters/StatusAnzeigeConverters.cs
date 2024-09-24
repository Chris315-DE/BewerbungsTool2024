using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BewerbungsTool.Converters
{
    class StatusAnzeigeConverters
    {
    }



    public class HeigtConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var conv = (double)value;
            return conv - double.Parse(parameter?.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class BoolListToColorConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            List<bool> list = (List<bool>)value;
            int index = int.Parse(parameter.ToString());

            if (list?.Count == 5 && list?[index] == true)
                return Brushes.Green;
            return Brushes.Red;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class BooltoProgressConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<bool> bools = (List<bool>)value;
            int progress = 0;

            foreach (var item in bools)
            {
                if (item) progress += 20;
            }
            return progress;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
