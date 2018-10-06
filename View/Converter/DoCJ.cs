using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Urban_Hra.View.Converter
{
    class DoCJ : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((string)value)
            {
                case "Red": return "Červená";
                case "Green": return "Zelená";
                case "Blue": return "Modrá";
                case "Yellow": return "Žlutá";
                case "Orange": return "Oranžová";
                default: return "_____";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
