using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkoló.Models
{
    public class Parkolo
    {
        public int Sor { get; set; }
        public int Oszlop { get; set; }
        public string Tipus { get; set; }
        public string Jarmu_rendszam { get; set; }

        public Parkolo(MySqlDataReader dataReader)
        {
            Sor = Convert.ToInt32(dataReader["sor"]);
            Oszlop = Convert.ToInt32(dataReader["oszlop"]);
            Tipus = dataReader["tipus"].ToString();
            Jarmu_rendszam = dataReader["jarmu_rendszam"].ToString();
        }

        public override bool Equals(object? obj)
        {
            var temp = obj as Parkolo;
            if (obj == null)
                return false;
            return Sor == temp.Sor && Oszlop == temp.Oszlop && Tipus == temp.Tipus && Jarmu_rendszam == temp.Jarmu_rendszam;
        }
    }
}
