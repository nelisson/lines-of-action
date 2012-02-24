using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using LinesOfAction.Enumerações;

namespace LinesOfAction.Conversores
{
    public class JogadorParaCorConversor : MarkupExtension, IValueConverter
    {
        #region Overrides of MarkupExtension

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion

        #region Implementation of IMultiValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Jogadores) value == Jogadores.Jogador1 ? Brushes.White : Brushes.DimGray;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return (Brush) value == Brushes.White ? Jogadores.Jogador1 : Jogadores.Jogador2;
        }

        #endregion
    }
}