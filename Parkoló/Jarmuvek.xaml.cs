using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Parkoló
{
    /// <summary>
    /// Interaction logic for Jarmuvek.xaml
    /// </summary>
    public partial class Jarmuvek : Window
    {
        public ObservableCollection<JarmuItem> JarmuvekTable { get; set; }

        public Jarmuvek()
        {
            InitializeComponent();

            JarmuvekTable = new ObservableCollection<JarmuItem>();
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id) && !string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                JarmuvekTable.Add(new JarmuItem { Id = id, Name = NameTextBox.Text });
                IdTextBox.Clear();
                NameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid Id and Name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (JarmuvekListView.SelectedItem is JarmuItem selectedItem)
            {
                if (int.TryParse(IdTextBox.Text, out int id) && !string.IsNullOrWhiteSpace(NameTextBox.Text))
                {
                    selectedItem.Id = id;
                    selectedItem.Name = NameTextBox.Text;
                    IdTextBox.Clear();
                    NameTextBox.Clear();
                    JarmuvekListView.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Please enter a valid Id and Name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to modify.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (JarmuvekListView.SelectedItem is JarmuItem selectedItem)
            {
                JarmuvekTable.Remove(selectedItem);
                IdTextBox.Clear();
                NameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
