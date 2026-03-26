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
        public MainWindow()
        {
            InitializeComponent();
            ParkoloSetup();
        }

        private void ParkoloSetup()
        {
            for (int i = 0; i < 10; i++)
            {
                var column = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                parkoloGrid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < 7; i++)
            {
                var row = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                parkoloGrid.RowDefinitions.Add(row);
            }

            var parkolok = new List<Border>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var border = new Border
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Background = Brushes.LightGray,
                        Height = 50,
                        Width = 50
                    };

                    if (i == 0 && j == 4)
                    {
                        border = new Border
                        {
                            Background = Brushes.LightYellow,
                            BorderBrush = Brushes.Red,
                            BorderThickness = new Thickness(0, 2, 0, 0),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Height = 50,
                            Width = 50
                        };
                    }
                    else if (j != 4 && (i == 1 || i == 4))
                    {
                        border = new Border
                        {
                            Background = Brushes.FloralWhite,
                            BorderBrush = Brushes.Black,
                            BorderThickness = new Thickness(2,0,2,2),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Height = 50,
                            Width = 50
                        };
                    }
                    else if (j != 4 && (i == 2 || i == 5))
                    {
                        border = new Border
                        {
                            Background = Brushes.FloralWhite,
                            BorderBrush = Brushes.Black,
                            BorderThickness = new Thickness(2,2,2,0),
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Height = 50,
                            Width = 50
                        };
                    }
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    parkolok.Add(border);
                    parkoloGrid.Children.Add(border);
                }
            }
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

        private void Tarifak_Click(object sender, RoutedEventArgs e)
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