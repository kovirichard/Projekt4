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
        public MainWindow()
        {
            InitializeComponent();
            ParkoloKezeloContext parkoloKezeloContext = new ParkoloKezeloContext();
            TesztEszkozok tesztEszkozok = new TesztEszkozok();
            tesztEszkozok.Show();

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