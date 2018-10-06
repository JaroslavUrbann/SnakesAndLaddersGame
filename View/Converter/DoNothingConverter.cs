
using System;
using Base.View.Converter;
using System.Windows.Data;

namespace Urban_Hra.View.Converter
{
    /// <summary>
    /// EN: Non abstract implementation of BaseConverter. Does basically nothing.
    /// CZ: Konkrétní implementace BaseConverter. V podstatě nic nepřevádí.
    /// </summary>
    internal class DoNothingConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value; // returns original type and value as string
        }
    }
}
