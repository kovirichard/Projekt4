using MySql.Data.MySqlClient;
using Parkoló.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Parkoló.Engine
{
    public class ParkoloKezeloContext
    {
        private string _server;
        private int _port;
        private string _database;
        private string _username;
        private string _password;

        public MySqlConnection Connection { get; private set; }

        public List<Parkolo> Parkolok { get; set; } = new List<Parkolo>();
        public List<Jarmu> Jarmuvek { get; set; } = new List<Jarmu>();
        public List<Esemeny> Esemenyek { get; set; } = new List<Esemeny>();
        public List<Tranzakcio> Tranzakciok { get; set; } = new List<Tranzakcio>();

        public ParkoloKezeloContext()
        {
            _server = "localhost";
            _port = 3300;
            _database = "parkolokezelo";
            _username = "root";
            _password = "";

            var sikeres = false;

            do
            {
                try
                {
                    Connection = new MySqlConnection($"server={_server};port={_port};database={_database};user={_username};password={_password}");
                    Connection.Open();
                    sikeres = true;
                    break;
                }
                catch (MySqlException)
                {
                    Connection?.Dispose();
                    _port++;
                }
            } while (_port <= 3310);

            if (sikeres)
            {
                Connection?.Close();
            }
            else
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz. Kérem ellenőrizze a beállításokat.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
        }



    }
}
