using Parkoló.Engine;
using Parkoló.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Parkoló
{
    public partial class jarmu : Window
    {
        private ParkoloKezeloContext _ctx;

        public jarmu()
        {
            InitializeComponent();
            _ctx = new ParkoloKezeloContext();
            RefreshListView();
        }

        private void RefreshListView()
        {
            lvJarmuvek.ItemsSource = null;
            lvJarmuvek.ItemsSource = _ctx.Jarmuvek.ToList();
        }

        private void lvJarmuvek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var jarmu = lvJarmuvek.SelectedItem as Jarmu;
            if (jarmu != null)
            {
                tbRendszam.Text = jarmu.Rendszam;
                tbTipus.Text = jarmu.Tipus;
                cbMozgaskorlatozott.IsChecked = jarmu.Mozgaskorlatozott;
                cbElektromos.IsChecked = jarmu.Elektromos;
                txtStatus.Text = $"Kijelölt jármű: {jarmu.Rendszam} ({jarmu.Tipus})";
            }
        }

        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            string rendszam = tbRendszam.Text.Trim();
            string tipus = tbTipus.Text.Trim();

            if (string.IsNullOrEmpty(rendszam) || string.IsNullOrEmpty(tipus))
            {
                MessageBox.Show("Töltsd ki a Rendszám és Típus mezőket!");
                return;
            }

            if (_ctx.Jarmuvek.Exists(x => x.Rendszam == rendszam))
            {
                MessageBox.Show("Ez a rendszám már létezik!");
                return;
            }

            Jarmu uj = new Jarmu
            {
                Rendszam = rendszam,
                Tipus = tipus,
                Mozgaskorlatozott = cbMozgaskorlatozott.IsChecked ?? false,
                Elektromos = cbElektromos.IsChecked ?? false
            };

            _ctx.Jarmuvek.Add(uj);
            _ctx.SaveChanges();
            RefreshListView();
            ClearFields();

            MessageBox.Show($"A jármű ({rendszam}) hozzáadva!");
            txtStatus.Text = $"Hozzáadva: {rendszam} ({tipus})";
        }

        private void Modositas_Click(object sender, RoutedEventArgs e)
        {
            var jarmu = lvJarmuvek.SelectedItem as Jarmu;
            if (jarmu != null)
            {

                jarmu.Tipus = tbTipus.Text.Trim();
                jarmu.Mozgaskorlatozott = cbMozgaskorlatozott.IsChecked ?? false;
                jarmu.Elektromos = cbElektromos.IsChecked ?? false;


                string sql = $"UPDATE jarmu " +
                             $"SET tipus='{jarmu.Tipus}', " +
                             $"mozgaskorlatozott={(jarmu.Mozgaskorlatozott ? 1 : 0)}, " +
                             $"elektromos={(jarmu.Elektromos ? 1 : 0)} " +
                             $"WHERE id={jarmu.Id}";

                _ctx.ExecuteNonQuery(sql);


                RefreshListView();
                MessageBox.Show($"A jármű ({jarmu.Rendszam}) módosításai mentve!");
                txtStatus.Text = $"Módosítva: {jarmu.Rendszam} ({jarmu.Tipus})";
            }
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            var jarmu = lvJarmuvek.SelectedItem as Jarmu;
            if (jarmu != null)
            {
                if (MessageBox.Show($"Biztos törlöd a járművet ({jarmu.Rendszam})?", "Figyelem", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string rendszam = jarmu.Rendszam;
                    string tipus = jarmu.Tipus;

                    _ctx.Jarmuvek.Remove(jarmu);
                    _ctx.SaveChanges();
                    RefreshListView();
                    ClearFields();

                    MessageBox.Show($"A jármű ({rendszam}) törlése sikeres!");
                    txtStatus.Text = $"Törölve: {rendszam} ({tipus})";
                }
            }
        }

        private void ClearFields()
        {
            tbRendszam.Text = "";
            tbTipus.Text = "";
            cbMozgaskorlatozott.IsChecked = false;
            cbElektromos.IsChecked = false;
            txtStatus.Text = "";
        }
    }
}