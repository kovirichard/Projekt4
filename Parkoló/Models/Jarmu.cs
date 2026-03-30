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

        public Jarmu()
        {

        }

        public Jarmu(MySqlDataReader dataReader) 
        {
            Id = dataReader.GetInt32("Id");
            Rendszam = dataReader["rendszam"].ToString();
            Tipus = dataReader["tipus"].ToString();
            Mozgaskorlatozott = Convert.ToBoolean(dataReader["mozgaskorlatozott"]);
            Elektromos = Convert.ToBoolean(dataReader["elektromos"]);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Jarmu temp)
                return false;

            return Id == temp.Id
                   && Rendszam == temp.Rendszam
                   && Tipus == temp.Tipus
                   && Mozgaskorlatozott == temp.Mozgaskorlatozott
                   && Elektromos == temp.Elektromos;
        }
    }
}
