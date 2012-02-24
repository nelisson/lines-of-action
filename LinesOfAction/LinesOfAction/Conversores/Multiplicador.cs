using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace LinesOfAction.Conversores
{
    public class Multiplicador : MarkupExtension, IValueConverter
    {
        public double Fator { get; set; }

        #region Overrides of MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion

        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double) value*Fator;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return (double) value/Fator;
            }
            catch (DivideByZeroException)
            {
                return value;
            }
        }

        #endregion
    }
}