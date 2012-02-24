using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinesOfAction.Controles
{
    /// <summary>
    ///   Interaction logic for Tabuleiro.xaml
    /// </summary>
    public partial class Tabuleiro
    {
        private BitArray _peçasBrancas;

        private BitArray _peçasPretas;

        public Tabuleiro()
        {
            InitializeComponent();
        }

        public BitArray PeçasBrancas
        {
            get { return _peçasBrancas ?? new BitArray(64, false); }
            set { _peçasBrancas = value; }
        }

        public BitArray PeçasPretas
        {
            get { return _peçasPretas ?? new BitArray(64, false); }
            set { _peçasPretas = value; }
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            Parallel.ForEach(Enumerable.Range(0, 9),
                             coluna => Dispatcher.BeginInvoke(new Action(() =>
                                                                             {
                                                                                 var rowDefinition =
                                                                                     new RowDefinition
                                                                                         {
                                                                                             Height =
                                                                                                 new GridLength
                                                                                                 (1,
                                                                                                  coluna == 0
                                                                                                      ? GridUnitType
                                                                                                            .
                                                                                                            Auto
                                                                                                      : GridUnitType
                                                                                                            .
                                                                                                            Star)
                                                                                         };
                                                                                 var columnDefinition =
                                                                                     new ColumnDefinition
                                                                                         {
                                                                                             Width =
                                                                                                 new GridLength
                                                                                                 (1,
                                                                                                  coluna == 0
                                                                                                      ? GridUnitType
                                                                                                            .
                                                                                                            Auto
                                                                                                      : GridUnitType
                                                                                                            .
                                                                                                            Star)
                                                                                         };

                                                                                 RowDefinitions.
                                                                                     Add(rowDefinition);
                                                                                 ColumnDefinitions
                                                                                     .Add(columnDefinition);
                                                                                 if (coluna != 0)
                                                                                 {
                                                                                     Parallel.ForEach(
                                                                                         Enumerable.Range(1,
                                                                                                          8),
                                                                                         linha =>
                                                                                         Dispatcher
                                                                                             .BeginInvoke(
                                                                                                 new Action(
                                                                                                     () =>
                                                                                                         {
                                                                                                             var
                                                                                                                 rec
                                                                                                                     =
                                                                                                                     new Rectangle
                                                                                                                         ();
                                                                                                             SetColumn
                                                                                                                 (rec,
                                                                                                                  coluna);
                                                                                                             SetRow
                                                                                                                 (
                                                                                                                     rec,
                                                                                                                     linha);

                                                                                                             Children
                                                                                                                 .
                                                                                                                 Add
                                                                                                                 (rec);
                                                                                                         })));
                                                                                 }
                                                                                 else
                                                                                 {
                                                                                     Parallel.ForEach(
                                                                                         Enumerable.Range(1,
                                                                                                          8),
                                                                                         i =>
                                                                                         Dispatcher.
                                                                                             BeginInvoke(
                                                                                                 new Action(
                                                                                                     () =>
                                                                                                         {
                                                                                                             var
                                                                                                                 labelColuna
                                                                                                                     =
                                                                                                                     new Label
                                                                                                                         {
                                                                                                                             Content
                                                                                                                                 =
                                                                                                                                 (
                                                                                                                                 char
                                                                                                                                 )
                                                                                                                                 ('A' +
                                                                                                                                  i -
                                                                                                                                  1),
                                                                                                                             HorizontalAlignment
                                                                                                                                 =
                                                                                                                                 HorizontalAlignment
                                                                                                                                 .
                                                                                                                                 Center,
                                                                                                                             VerticalAlignment
                                                                                                                                 =
                                                                                                                                 VerticalAlignment
                                                                                                                                 .
                                                                                                                                 Bottom,
                                                                                                                             Foreground
                                                                                                                                 =
                                                                                                                                 Brushes
                                                                                                                                 .
                                                                                                                                 AntiqueWhite,
                                                                                                                             FontSize
                                                                                                                                 =
                                                                                                                                 16
                                                                                                                         };
                                                                                                             var
                                                                                                                 labelLinha
                                                                                                                     =
                                                                                                                     new Label
                                                                                                                         {
                                                                                                                             Content
                                                                                                                                 =
                                                                                                                                 i,
                                                                                                                             HorizontalAlignment
                                                                                                                                 =
                                                                                                                                 HorizontalAlignment
                                                                                                                                 .
                                                                                                                                 Right,
                                                                                                                             VerticalAlignment
                                                                                                                                 =
                                                                                                                                 VerticalAlignment
                                                                                                                                 .
                                                                                                                                 Center,
                                                                                                                             Foreground
                                                                                                                                 =
                                                                                                                                 Brushes
                                                                                                                                 .
                                                                                                                                 AntiqueWhite,
                                                                                                                             FontSize
                                                                                                                                 =
                                                                                                                                 16
                                                                                                                         };
                                                                                                             SetColumn
                                                                                                                 (labelColuna,
                                                                                                                  i);
                                                                                                             SetRow
                                                                                                                 (
                                                                                                                     labelLinha,
                                                                                                                     i);

                                                                                                             Children
                                                                                                                 .
                                                                                                                 Add
                                                                                                                 (labelLinha);

                                                                                                             Children
                                                                                                                 .
                                                                                                                 Add
                                                                                                                 (
                                                                                                                     labelColuna);
                                                                                                         })));
                                                                                 }
                                                                             })));
        }
    }
}