using System;
using MySql.Data.MySqlClient;

namespace YeahFit
{
    public class InitializeWeek
    {
        MySqlConnection con;
        public static bool monday = false;
        public static bool tuesday = false;
        public static bool wednesday = false;
        public static bool thursday = false;
        public static bool friday = false;
        public static bool saturday = false;
        public static bool sunday = false;
        public static int wochenid = 1;

        public InitializeWeek()
        {
            //select all
            //alles in werte

        }

        public void Inizialize()
        {
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();

            
        }
	}
}

