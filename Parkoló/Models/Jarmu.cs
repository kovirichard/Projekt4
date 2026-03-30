using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkoló.Models
{
    public class Jarmu
    {
        public int Id { get; set; }
        public string Rendszam { get; set; }
        public string Tipus { get; set; }
        public bool Mozgaskorlatozott { get; set; }
        public bool Elektromos { get; set; }

        public Jarmu(MySqlDataReader dataReader) 
        {
            Id = Convert.ToInt32(dataReader["id"]);
            Rendszam = dataReader["rendszam"].ToString();
            Tipus = dataReader["tipus"].ToString();
            Mozgaskorlatozott = Convert.ToBoolean(dataReader["mozgaskorlatozott"]);
            Elektromos = Convert.ToBoolean(dataReader["elektromos"]);
        }

        public override bool Equals(object? obj)
        {
            var temp = obj as Jarmu;
            if (obj == null)
                return false;
            return Id == temp.Id && Rendszam == temp.Rendszam && Tipus == temp.Tipus && Mozgaskorlatozott == temp.Mozgaskorlatozott && Elektromos == temp.Elektromos;
        }
    }
}
