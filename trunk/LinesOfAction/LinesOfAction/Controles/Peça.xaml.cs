using System;
using System.ComponentModel;
using System.Windows;
using LinesOfAction.Enumerações;

namespace LinesOfAction.Controles
{
    /// <summary>
    ///   Interaction logic for Peça.xaml
    /// </summary>
    public partial class Peça : INotifyPropertyChanged
    {
        public static readonly DependencyProperty JogadorProperty =
            DependencyProperty.Register("Jogador", typeof (Jogadores), typeof (Peça),
                                        new UIPropertyMetadata(Jogadores.Jogador1));

        private int _coluna;

        private int _linha;

        public Peça()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        public int Linha
        {
            get { return _linha; }
            set
            {
                _linha = value;
                NotifyPropertyChanged("Linha");
            }
        }

        public int Coluna
        {
            get { return _coluna; }
            set
            {
                _coluna = value;
                NotifyPropertyChanged("Coluna");
            }
        }

        public Jogadores Jogador
        {
            get { return (Jogadores) GetValue(JogadorProperty); }
            set { SetValue(JogadorProperty, value); }
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            DataContext = this;
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}