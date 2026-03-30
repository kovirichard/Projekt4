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
            _port = 3306;
            _database = "parkolokezelo";
            _username = "root";
            _password = "";

            Connection = new MySqlConnection($"server={_server};port={_port};database={_database};user={_username};password={_password}");
            try
            {
                Connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz. Kérem ellenőrizze a beállításokat.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Windows.Application.Current.Shutdown();
            }
            finally
            {
                Connection.Close();
            }

            /*
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
            */

            Parkolok = Read<Parkolo>(dataReader => new Parkolo(dataReader));
            Jarmuvek = Read<Jarmu>(dataReader => new Jarmu(dataReader));
            Esemenyek = Read<Esemeny>(dataReader => new Esemeny(dataReader));
            Tranzakciok = Read<Tranzakcio>(dataReader => new Tranzakcio(dataReader));
        }

        private List<T> Read<T>(Func<MySqlDataReader, T> tipusKeszites)
        {
            var tabla = new List<T>();

            try
            {
                Connection.Open();
                var cmd = new MySqlCommand(GenerateSelect(typeof(T)), Connection);
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    tabla.Add(tipusKeszites(dataReader));
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Connection.Close();
            }
            return tabla;
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                Connection.Open();
                var cmd = new MySqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }

        public int SaveChanges()
        {
            var parkoloDB = Read(x => new Parkolo(x));
            var parkoloChanges = SaveTable(parkoloDB, Parkolok);

            var jarmuDB = Read(x => new Jarmu(x));
            var jarmuChanges = SaveTable(jarmuDB, Jarmuvek);

            var esemenyDB = Read(x => new Esemeny(x));
            var esemenyChanges = SaveTable(esemenyDB, Esemenyek);

            var tranzakcioDB = Read(x => new Tranzakcio(x));
            var tranzakcioChanges = SaveTable(tranzakcioDB, Tranzakciok);

            if (parkoloChanges > 0)
                Parkolok = Read(x => new Parkolo(x));

            if (jarmuChanges > 0)
                Jarmuvek = Read(x => new Jarmu(x));

            if (esemenyChanges > 0)
                Esemenyek = Read(x => new Esemeny(x));

            if (tranzakcioChanges > 0)
                Tranzakciok = Read(x => new Tranzakcio(x));

            return parkoloChanges + jarmuChanges + esemenyChanges + tranzakcioChanges;
        }

        private int SaveTable<T>(List<T> dbtable, List<T> list)
        {
            var changes = 0;

            foreach (var item in list)
            {
                var itemDB = dbtable.FirstOrDefault(x => x.GetType().GetProperty("Id").GetValue(x) ==
                                    item.GetType().GetProperty("Id").GetValue(item));

                if (itemDB == null)
                {
                    ExecuteNonQuery(GenerateInsert(item));
                    changes++;
                }
                else
                {
                    if (!item.Equals(itemDB))
                    {
                        ExecuteNonQuery(GenerateUpdate(item));
                        changes++;
                    }
                    dbtable.Remove(itemDB);
                }
            }

            foreach (var itemDB in dbtable)
            {
                ExecuteNonQuery(GenerateDelete(itemDB));
                changes++;
            }

            return changes;
        }

        private string GenerateSelect(Type type)
        {
            return $"SELECT * FROM {type.Name.ToLower()}";
        }

        private string GenerateInsert(Object obj)
        {
            var insert = $"INSERT INTO `{obj.GetType().Name}`";
            var attributes = "(";
            var values = "VALUES (";
            foreach (var propInfo in obj.GetType().GetProperties())
            {
                if (propInfo.Name != "Id")
                {
                    attributes += $"`{propInfo.Name}`,";
                    values += $"'{propInfo.GetValue(obj)}',";
                }
            }
            attributes = attributes.Substring(0, attributes.Length - 1) + ") ";
            values = values.Substring(0, values.Length - 1) + ")";

            return insert + attributes + values;
        }

        private string GenerateUpdate(Object obj)
        {
            var update = $"UPDATE `{obj.GetType().Name}` ";
            var set = "SET ";
            var where = "WHERE ";

            foreach (var propInfo in obj.GetType().GetProperties())
            {
                if (propInfo.Name != "Id")
                    set += $"`{propInfo.Name}`='{propInfo.GetValue(obj)}',";
                else
                    where += $"`{propInfo.Name}`='{propInfo.GetValue(obj)}'";
            }
            set = set.Substring(0, set.Length - 1) + " ";

            return update + set + where;
        }

        private string GenerateDelete(Object obj)
        {
            var delete = $"DELETE FROM `{obj.GetType().Name}` ";
            var where = $"WHERE `id`='{obj.GetType().GetProperty("Id")!.GetValue(obj)}'";

            return delete + where;
        }
    }
}
