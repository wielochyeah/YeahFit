using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace YeahFit
{
	public class InitializeExercises
	{

        public static MySqlConnection con;
        public static List<InternalExercise> exercises = new List<InternalExercise>();

		public InitializeExercises()
		{
		}

		public static void Initialize()
		{
            // Create an empty list of workouts.
            exercises = new List<InternalExercise>();

            // Open a connection to the YeahFit database on the local server with the root user and empty password.
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();

            // Select every exercise
            using (MySqlCommand getexercises = new MySqlCommand($"SELECT * FROM `Übung`;", con))
            {
                // Execute the SQL query and get the result set
                using (MySqlDataReader reader = getexercises.ExecuteReader())
                {
                    // Iterate through each row of the result set
                    while (reader.Read())
                    {
                        // Extract the exercise name from the current row
                        string name = reader["ÜbungName"].ToString();

                        int id = Convert.ToInt32(reader["ÜbungID"]);

                        // Extract the exercise image from the current row
                        byte[] imgg = (byte[])(reader["ÜbungGIF"]);

                        // Create a new Exercise object with the extracted information
                        InternalExercise exercise = new InternalExercise
                        {
                            ExerciseName = name,
                            ExerciseID = id,
                            ExerciseImage = imgg,
                        };

                            // Add the exercise to the current workout's list of exercises
                            exercises.Add(exercise);

                    }
                }
            }

            // close connection
            con.Close();
        }
	}
}

