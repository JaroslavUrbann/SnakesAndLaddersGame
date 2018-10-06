using System;
using System.Windows.Data;

namespace Base.View.Converter
{
    /// <summary>
    /// EN: Provides a common foundation for applying custom logic to binding.
    /// CZ: Poskytuje základní funkcionalitu pro interpretování bindovaných dat.
    /// </summary>
    /// <see>https://msdn.microsoft.com/cs-cz/library/system.windows.data.ivalueconverter(v=vs.110).aspx</see>
    internal abstract class BaseConverter : IValueConverter
    {
        /// <summary>
        /// EN: Converts a value
        /// CZ: Interpretuje hodnotu - konvertuje hodnotu na cílový typ
        /// </summary>
        /// <param name="value">EN: The value produced by the binding source. CZ: Bindovaná hodnota</param>
        /// <param name="targetType">EN: The type of the binding target property. CZ: Cílový typ interpretované bindované hodnoty</param>
        /// <param name="parameter">EN: The converter parameter to use. CZ:  Parametr bindování</param>
        /// <param name="culture">EN: The culture to use in the converter. CZ: Nastavení kultury použité během konverze (národní formáty, apod.)</param>
        /// <returns>EN: A converted value.If the method returns null, the valid null value is used. CZ: Konvertovaná hodnota. Může vracet null.</returns>
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.GetType().ToString() + ": " + value; // returns original type and value as string
        }

        /// <summary>
        /// EN: Converts a value
        /// CZ: Interpretuje hodnotu - konvertuje hodnotu na cílový typ
        /// </summary>
        /// <param name="value">EN: The value produced by the binding source. CZ: Bindovaná hodnota</param>
        /// <param name="targetType">EN: The type of the binding target property. CZ: Cílový typ interpretované bindované hodnoty</param>
        /// <param name="parameter">EN: The converter parameter to use. CZ:  Parametr bindování</param>
        /// <param name="culture">EN: The culture to use in the converter. CZ: Nastavení kultury použité během konverze (národní formáty, apod.)</param>
        /// <returns>EN: A converted value.If the method returns null, the valid null value is used. CZ: Konvertovaná hodnota. Může vracet null.</returns>
        /// <exception>NotImplementedException is thrown by default</exception>
        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

