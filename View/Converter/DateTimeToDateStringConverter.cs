using System;
using Base.View.Converter;

namespace Urban_Hra.View.Converter
{
    internal class DateTimeToDateStringConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime val = (DateTime)value;
                string date = val.ToString(culture.DateTimeFormat.LongDatePattern);
                return (date);
            }
            else
                return base.Convert(value, targetType, parameter, culture);
        }
    }
}
