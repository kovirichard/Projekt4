using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkoló.Models
{
    public class Esemeny
    {
        public int Id { get; set; }
        public string Rendszam { get; set; }
        public DateTime Parkolas_kezdete { get; set; }
        public DateTime Parkolas_vege { get; set; } = DateTime.MaxValue;

        public Esemeny (MySqlDataReader dataReader)
        {
            Id = Convert.ToInt32(dataReader["id"]);
            Rendszam = dataReader["rendszam"].ToString();
            Parkolas_kezdete = Convert.ToDateTime(dataReader["parkolas_kezdete"]);
            Parkolas_vege = Convert.ToDateTime(dataReader["parkolas_vege"]);
        }

        public override bool Equals(object? obj)
        {
            var temp = obj as Esemeny;
            if (obj == null)
                return false;
            return Id == temp.Id && Rendszam == temp.Rendszam && Parkolas_kezdete == temp.Parkolas_kezdete && Parkolas_vege == temp.Parkolas_vege;
        }
    }
}
