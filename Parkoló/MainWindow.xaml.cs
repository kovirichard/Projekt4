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
        ParkoloKezeloContext parkoloKezeloContext = new ParkoloKezeloContext();
        public MainWindow()
        {
            InitializeComponent();
            TesztEszkozok tesztEszkozok = new TesztEszkozok();
            tesztEszkozok.Show();
            GenerateParkolo();

        }

        public void GenerateParkolo()
        {
            Viewbox viewbox = new Viewbox();
            Border border = new Border
            {
                BorderBrush = Brushes.SlateGray,
                BorderThickness = new Thickness(3)
            };
            Grid grid = new Grid();

            for (int i = 0; i <= parkoloKezeloContext.Parkolok.Max(x => x.Sor); i++)
            {
                for (int j = 0; j <= parkoloKezeloContext.Parkolok.Max(x => x.Oszlop); j++)
                {
                    var parkolo = parkoloKezeloContext.Parkolok.FirstOrDefault(x => x.Sor == i && x.Oszlop == j);
                    if (parkolo != null)
                    {
                        Rectangle rectangle = new Rectangle
                        {
                            Fill = parkolo.Jarmu_rendszam == "" ? Brushes.Red : Brushes.Green,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1,
                            Width = 50,
                            Height = 50
                        };
                        grid.Children.Add(rectangle);
                    }
                }
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