using System;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace YeahFit
{
	public class InitializeAwards
	{
        MySqlConnection con;
        public static int perfectWeek = 0;
        public static int perfectMonth = 0;
        public static int perfectYear = 0;
        public static int completeAdvancedWorkout = 0;
        public static int startAChallenge = 0;
        public static int completeHardWorkout = 0;

        public InitializeAwards()
        {
        }
        public void Initialize()
		{
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();

            MySqlCommand initialize = new MySqlCommand($"SELECT * From Benutzer_Awards WHERE BenutzerID = {LoginViewController.userID}", con);

            using (MySqlDataReader reader = initialize.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["AwardID"]) == 1)
                    {
                        perfectWeek = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        perfectWeek = 0;
                    }

                    if (Convert.ToInt32(reader["AwardID"]) == 2)
                    {
                        perfectMonth = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        perfectMonth = 0;
                    }

                    if (Convert.ToInt32(reader["AwardID"]) == 3)
                    {
                        perfectYear = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        perfectYear = 0;
                    }

                    if (Convert.ToInt32(reader["AwardID"]) == 4)
                    {
                        completeAdvancedWorkout = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        completeAdvancedWorkout = 0;
                    }

                    if (Convert.ToInt32(reader["AwardID"]) == 5)
                    {
                        startAChallenge = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        startAChallenge = 0;
                    }

                    if (Convert.ToInt32(reader["AwardID"]) == 6)
                    {
                        completeHardWorkout = Convert.ToInt32(reader["AwardZähler"]);
                    }
                    else
                    {
                        completeHardWorkout = 0;
                    }
                }
            }
        }
	}
}

