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

        }

        public void Initialize()
        {
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();


            MySqlCommand initialize = new MySqlCommand($"SELECT * From Woche w, Benutzer_Woche b WHERE w.WochenID = b.WochenID AND BenutzerID = {LoginViewController.userID}", con);

            using (MySqlDataReader reader = initialize.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["Montag"].ToString() == "True")
                    {
                        monday = true;
                    }
                    else
                    {
                        monday = false;
                    }

                    if (reader["Dienstag"].ToString() == "True")
                    {
                        tuesday = true;
                    }
                    else
                    {
                        monday = false;
                    }

                    if (reader["Mittwoch"].ToString() == "True")
                    {
                        wednesday = true;
                    }
                    else
                    {
                        wednesday = false;
                    }

                    if (reader["Donnerstag"].ToString() == "True")
                    {
                        thursday = true;
                    }
                    else
                    {
                        thursday = false;
                    }

                    if (reader["Freitag"].ToString() == "True")
                    {
                        friday = true;
                    }
                    else
                    {
                        friday = false;
                    }

                    if (reader["Samstag"].ToString() == "True")
                    {
                        saturday = true;
                    }
                    else
                    {
                        saturday = false;
                    }

                    if (reader["Sonntag"].ToString() == "True")
                    {
                        sunday = true;
                    }
                    else
                    {
                        sunday = false;
                    }
                }
            }
        }
	}
}

