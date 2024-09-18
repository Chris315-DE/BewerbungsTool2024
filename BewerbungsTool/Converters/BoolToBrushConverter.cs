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
    class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            bool vbool = (bool)value;

            if (vbool) return new SolidColorBrush(Color.FromRgb(190, 213, 255));

            else return new SolidColorBrush(Color.FromRgb(255, 255, 255));   
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
