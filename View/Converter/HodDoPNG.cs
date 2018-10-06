using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Urban_Hra.View.Converter
{
    class HodDoPNG : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int HozeneCislo = (int)value;
            string HozeneCisloPNG = "/Assets/" + HozeneCislo.ToString() + ".png";
            return HozeneCisloPNG;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
