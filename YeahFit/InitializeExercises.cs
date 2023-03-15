using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace YeahFit
{
	public class InitializeExercises
	{

        public static MySqlConnection con;
        public static List<Exercise> exercises = new List<Exercise>();

		public InitializeExercises()
		{
		}

		public void Initialize()
		{
            // Create an empty list of workouts.
            exercises = new List<Exercise>();

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

                        string sets = reader["Sätze"].ToString();
                        string reps = reader["Wiederholungen"].ToString();

                        // Extract the exercise image from the current row
                        byte[] imgg = (byte[])(reader["ÜbungGIF"]);

                        // Create a new Exercise object with the extracted information
                        Exercise exercise = new Exercise
                        {
                            ExerciseName = name,
                            ExerciseReps = reps,
                            ExerciseSets = sets,
                            ExerciseImage = imgg,
                        };

                        // Iterate through each workout in the list of workouts
                        for (int j = 0; j < exercises.Count; j++)
                        {
                            // Add the exercise to the current workout's list of exercises
                            exercises.Add(exercise);
                        }

                    }
                }
            }

            // close connection
            con.Close();
        }
	}
}

