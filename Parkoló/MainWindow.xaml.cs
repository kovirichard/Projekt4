using Parkoló.Engine;
using Parkoló.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parkoló
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkoloKezeloContext ctx { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ctx = new ParkoloKezeloContext();
            TesztEszkozok tesztEszkozok = new TesztEszkozok();
            tesztEszkozok.Show();
            GenerateParkolo();

        }

        public void GenerateParkolo()
        {
            Viewbox viewbox = new Viewbox();
            viewbox.Margin = new Thickness(30);
            Border border = new Border
            {
                BorderBrush = Brushes.SlateGray,
                BorderThickness = new Thickness(3)
            };
            Grid grid = new Grid();

            for (int i = 0; i <= ctx.Parkolok.Max(x => x.Sor)+1; i++)
            {
                var sor = new RowDefinition();
                sor.Height = new GridLength(50);
                grid.RowDefinitions.Add(sor);
            }
            for (int j = 0; j <= ctx.Parkolok.Max(x => x.Oszlop)+1; j++)
            {
                var oszlop = new ColumnDefinition();
                oszlop.Width = new GridLength(50);
                grid.ColumnDefinitions.Add(oszlop);
            }

            foreach (var hely in ctx.Parkolok)
            {
                
            }

            border.Child = grid;
            viewbox.Child = border;
            Grid.SetColumn(viewbox, 1);
            mainGrid.Children.Add(viewbox);
        }

        private void Jarmuvek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Parkolok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Esemenyek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tranzakciok_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Statisztikak_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}