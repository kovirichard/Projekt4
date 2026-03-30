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
        List<Border> parkoloHelyek { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ctx = new ParkoloKezeloContext();
            parkoloHelyek = new List<Border>();

            TesztEszkozok tesztEszkozok = new TesztEszkozok(ctx, parkoloHelyek);
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
                BorderThickness = new Thickness(3),
                Padding = new Thickness(5),
                Background = Brushes.Gray
            };

            Grid grid = new Grid();

            int sorokSzama = ctx.Parkolok.Max(x => x.Sor);
            int oszlopokSzama = ctx.Parkolok.Max(x => x.Oszlop);

            for (int i = 0; i <= sorokSzama; i++)
            {
                var sor = new RowDefinition();
                sor.Height = new GridLength(1, GridUnitType.Star);
                grid.RowDefinitions.Add(sor);
            }
            for (int j = 0; j <= oszlopokSzama; j++)
            {
                var oszlop = new ColumnDefinition();
                oszlop.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(oszlop);
            }

            foreach (var parkolo in ctx.Parkolok)
            {
                Border hely = new Border
                {
                    BorderBrush = Brushes.WhiteSmoke,
                    BorderThickness = new Thickness(oszlopokSzama / 2 + 1 == parkolo.Oszlop ? 6 : 3,
                                                    parkolo.Sor % 2 == 0 ? 0 : 3,
                                                    oszlopokSzama / 2 == parkolo.Oszlop ? 6 : 3,
                                                    parkolo.Sor % 2 == 0 ? 3 : 0),

                    Margin = new Thickness(oszlopokSzama / 2 + 1 == parkolo.Oszlop ? 25 : 0,
                                           parkolo.Sor % 2 == 0 ? 25 : 0,
                                           oszlopokSzama / 2 == parkolo.Oszlop ? 25 : 0,
                                           parkolo.Sor % 2 == 0 ? 0 : 25),
                    Height = 50,
                    Width = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                StackPanel stackPanel = new StackPanel();

                stackPanel.Children.Add(new TextBlock
                {
                    Text = parkolo.Jarmu_rendszam == "" ? "-" : parkolo.Jarmu_rendszam,
                    FontSize = 15,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.WhiteSmoke,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                });

                if (parkolo.Tipus == "elektromos")
                {
                    stackPanel.Children.Add(new TextBlock
                    {
                        Text = "⚡",
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.WhiteSmoke,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                }
                else if (parkolo.Tipus == "mozgasserult")
                {
                    stackPanel.Children.Add(new TextBlock
                    {
                        Text = "♿",
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.WhiteSmoke,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                }

                hely.Child = stackPanel;

                Grid.SetRow(hely, parkolo.Sor);
                Grid.SetColumn(hely, parkolo.Oszlop);

                parkoloHelyek.Add(hely);
                grid.Children.Add(hely);
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