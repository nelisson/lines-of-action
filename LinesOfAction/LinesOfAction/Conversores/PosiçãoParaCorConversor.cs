using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace LinesOfAction.Conversores
{
    public class PosiçãoParaCorConversor : MarkupExtension, IMultiValueConverter
    {
        #region Overrides of MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion

        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cor = new SolidColorBrush {Color = Color.FromRgb(209, 140, 71)};

            var linha = values.Cast<int>().First();
            var coluna = values.Cast<int>().Last();

            if ((linha + coluna)%2 == 0)
                cor.Color = Color.FromRgb(255, 209, 158);

            return cor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}