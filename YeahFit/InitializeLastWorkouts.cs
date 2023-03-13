using System;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Collections.Generic;

namespace YeahFit
{
	public class InitializeLastWorkouts
	{
        MySqlConnection con;

        public static DateTime WorkoutDateTime;
        public static int WorkoutID;
        public static List<LastWorkout> LastWorkout = new List<LastWorkout>();

        public InitializeLastWorkouts()
        {
        }
        public void Initialize()
        {
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();

            MySqlCommand initialize = new MySqlCommand($"SELECT * From Benutzer_Workout_Woche WHERE BenutzerID = {LoginViewController.userID}", con);

            using (MySqlDataReader reader = initialize.ExecuteReader())
            {
                while (reader.Read())
                {
                    LastWorkout lastWorkout = new LastWorkout
                    {
                        WorkoutID = Convert.ToInt32(reader["WorkoutID"]),
                        WorkoutDateTime = Convert.ToDateTime(reader["WorkoutDatum"]),
                    };
                    LastWorkout.Add(lastWorkout);
                }
            }
        }
	}
}

