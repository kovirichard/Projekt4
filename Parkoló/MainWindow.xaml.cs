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
        private List<Border> Parkolohelyek { get; set; } = new List<Border>();

        public MainWindow()
        {
            InitializeComponent();
            GenerateParkolo();
            (Parkolohelyek.First(x => x.Name == "hely12").Child as TextBlock).Text = "ABC-123";
        }

        private void GenerateParkolo()
        {
            Viewbox viewBox = new Viewbox
            {
                Margin = new Thickness(30)
            };
            Grid.SetColumn(viewBox, 1);

            Grid parkoloGrid = new Grid
            {
                Name = "parkoloGrid",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.DimGray
            };

            parkoloGrid.RowDefinitions.Add(new RowDefinition { MinHeight = 50 });
            parkoloGrid.RowDefinitions.Add(new RowDefinition());
            parkoloGrid.RowDefinitions.Add(new RowDefinition());
            parkoloGrid.RowDefinitions.Add(new RowDefinition { MinHeight = 50 });
            parkoloGrid.RowDefinitions.Add(new RowDefinition());
            parkoloGrid.RowDefinitions.Add(new RowDefinition());
            parkoloGrid.RowDefinitions.Add(new RowDefinition { MinHeight = 50 });

            for (int i = 0; i < 9; i++)
            {
                parkoloGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int[] helyek = { 1, 2, 4, 5 };
            foreach (int row in helyek)
            {
                for (int col = 0; col < 9; col++)
                {
                    Border border = new Border
                    {
                        Width = 50,
                        Height = 50
                    };

                    border.Name = $"hely{row}{col}";

                    if (col == 0) border.Margin = new Thickness(10, 0, 0, 0);
                    if (col == 8) border.Margin = new Thickness(0, 0, 10, 0);

                    if (col != 4)
                    {
                        border.BorderBrush = Brushes.WhiteSmoke;
                        int left = 1;
                        int top = (row == 2 || row == 5) ? 1 : 0;
                        int right = (col == 3 || col == 8) ? 1 : 0;
                        int bottom = (row == 1 || row == 4) ? 1 : 0;

                        border.BorderThickness = new Thickness(left, top, right, bottom);
                    }

                    border.Child = new TextBlock
                    {
                        Text = "",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Foreground = Brushes.WhiteSmoke
                    };

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);

                    parkoloGrid.Children.Add(border);
                    Parkolohelyek.Add(border);
                }
            }
            viewBox.Child = parkoloGrid;
            mainGrid.Children.Add(viewBox);
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