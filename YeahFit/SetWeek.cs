using System;
using System.Data.SqlClient;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace YeahFit
{
	public class SetWeek
	{
        public static MySqlConnection con;

        static int weekID = 0;

        public SetWeek()
		{
		}

        public static void SelectSetWeek(bool internalMonday, bool internalTuesday, bool internalWednesday, bool internalThursday, bool internalFriday, bool internalSaturday, bool internalSunday)
        {
            if (LoginViewController.loggedin == true)
            {
                weekID = 0;

                // Open a connection to the YeahFit database on the local server with the root user and empty password.
                con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
                con.Open();
                using (MySqlCommand getWeek = new MySqlCommand($"SELECT * FROM `Woche` " +
                    $"WHERE Montag='{internalMonday}' " +
                    $"AND Dienstag='{internalTuesday}' " +
                    $"AND Mittwoch='{internalWednesday}' " +
                    $"AND Donnerstag='{internalThursday}' " +
                    $"AND Freitag='{internalFriday}' " +
                $"AND Samstag='{internalSaturday}' " +
                    $"AND Sonntag='{internalSunday}' ", con))
                {
                    using (MySqlDataReader reader = getWeek.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            weekID = Convert.ToInt32(reader["WochenID"]);
                        }
                    }
                }
                if (weekID == 0)
                {
                    MySqlCommand insert = new MySqlCommand($"INSERT INTO Woche (Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag) " +
                        $"VALUES ({internalMonday}, {internalTuesday}, {internalWednesday}, {internalThursday}, {internalFriday}, {internalSaturday}, {internalSunday});", con);
                    insert.ExecuteNonQuery();
                    using (MySqlCommand getNewWeek = new MySqlCommand($"SELECT Woche.WochenID FROM `Woche`, `Benutzer_Woche` " +
                        $"WHERE Woche.WochenID = Benutzer_Woche.WochenID " +
                        $"AND Benutzer_Woche.BenutzerID = {LoginViewController.userID}", con))
                    {
                        using (MySqlDataReader reader2 = getNewWeek.ExecuteReader())
                        {

                            while (reader2.Read())
                            {
                                weekID = Convert.ToInt32(reader2["WochenID"]);
                            }
                        }
                    }
                    InitializeWeek.wochenid = weekID;
                }
                else
                {
                    MySqlCommand insert2 = new MySqlCommand($"INSERT INTO Benutzer_Woche (BenutzerID, WochenID) " +
                        $"VALUES ('{LoginViewController.userID}', '{weekID}';", con);
                    insert2.ExecuteNonQuery();
                }
                con.Close();
            }
        }
	}
}

