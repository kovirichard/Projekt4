using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkoló.Models
{
    public class Tranzakcio
    {
        public int Id { get; set; }
        public string Rendszam { get; set; }
        public double Osszeg { get; set; }
        public DateTime Datum { get; set; }

        public Tranzakcio(MySqlDataReader dataReader)
        {
            Id = Convert.ToInt32(dataReader["id"]);
            Rendszam = dataReader["rendszam"].ToString();
            Osszeg = Convert.ToDouble(dataReader["osszeg"]);
            Datum = Convert.ToDateTime(dataReader["datum"]);
        }

        public override bool Equals(object? obj)
        {
            var temp = obj as Tranzakcio;
            if (obj == null)
                return false;
            return Id == temp.Id && Rendszam == temp.Rendszam && Osszeg == temp.Osszeg && Datum == temp.Datum;
        }
    }
}
