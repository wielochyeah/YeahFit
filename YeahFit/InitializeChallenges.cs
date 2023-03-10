using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace YeahFit
{
	public class InitializeChallenges
	{
        public static MySqlConnection con;
        public static List<Challenge> challenges = new List<Challenge>();
        public static List<Workout> workouts = new List<Workout>();
        public List<Workout> Workouts;
        public static string filter;
        public static string order = "LastAdded";
        public static string orderby;
        public static bool favourite;
        public static string difficulty;
        public static string search;

        public InitializeChallenges()
        {
        }

        /// <summary>
        /// This method initializes the list of challenges with different filtering and ordering options.
        /// </summary>
        public static void Initialize()
        {
            // Create an empty list of challenges.
            challenges = new List<Challenge>();

            // Open a connection to the YeahFit database on the local server with the root user and empty password.
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();


            //
            // Filter the challegnes based on the selected category.
            //

            // Order by

            // Last added
            if (order == "LastAdded")
            {
                orderby = " ORDER BY Challenge.ChallengeID DESC";
            }
            // First added
            else if (order == "FirstAdded")
            {
                orderby = " ORDER BY Challenge.ChallengeID ASC";
            }
            // Alphabetical ascending
            else if (order == "AlphAsc")
            {
                orderby = " ORDER BY Challenge.ChallengeName ASC";
            }
            // Alphabetical descending
            else if (order == "AlphDesc")
            {
                orderby = " ORDER BY Challenge.ChallengeName DESC";
            }


            // Favourite/Liked
            if (favourite == true)
            {
                if (filter == "")
                {
                    filter = " WHERE Challenge.Liked = 1";
                }
                else
                {
                    filter = filter + " AND Challenge.Liked = 1";
                }
            }

            // Difficulty
            // Beginner
            if (difficulty == "beginner")
            {
                if (filter == "")
                {
                    filter = ", Schwierigkeit " +
                        "WHERE Challenge.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                        "AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Beginner'";
                }
                else
                {
                    filter = filter + " AND Rezept.Schwierigkeit = 'beginner'";
                }
            }
            // Advanced
            else if (difficulty == "advanced")
            {
                if (filter == "")
                {
                    filter = ", Schwierigkeit " +
                        "WHERE Challenge.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                        "AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Fortgeschritten'";
                }
                else
                {
                    filter = filter + " AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Fortgeschritten'";
                }
            }
            // Hard
            else if (difficulty == "hard")
            {
                if (filter == "")
                {
                    filter = ", Schwierigkeit " +
                        "WHERE Challenge.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                        "AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Hart'";
                }
                else
                {
                    filter = filter + " AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Hart'";
                }
            }

            // Searchbar
            if (search != "" && search != null)
            {
                if (filter == "")
                {
                    filter = $" WHERE Challenge.ChallengeName LIKE '%{search}%'";
                }
                else
                {
                    filter = filter + $" AND Challenge.WorkoutName LIKE '%{search}%'";
                }
            }

            // Read every challenge
            //  + filter
            //  + orderby
            using (MySqlCommand getmainchallenge = new MySqlCommand($"SELECT * FROM `Challenge` {filter} {orderby}", con))
            {
                using (MySqlDataReader reader = getmainchallenge.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int id = Convert.ToInt32(reader["ChallengeID"].ToString());
                        string name = reader["ChallengeName"].ToString();
                        bool liked;
                        if (reader["Liked"].ToString() == "True")
                        {
                            liked = true;
                        }
                        else
                        {
                            liked = false;
                        }

                        byte[] imgg = (byte[])(reader["Bild"]);

                        // Create new challenge
                        Challenge challenge = new Challenge
                        {
                            id = id,
                            ChallengeName = name,
                            difficulty = "",
                            liked = liked,
                            Workouts = new List<Workout>(),
                            ChallengeImage = imgg,
                        };

                        // Add to challenges list
                        challenges.Add(challenge);
                    }
                }

                // Get difficutly
                using (MySqlCommand getchallengedifficulty = new MySqlCommand($"SELECT * FROM `Challenge`, `Schwierigkeit` " +
                    $"WHERE Challenge.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID;", con))
                {
                    using (MySqlDataReader reader2 = getchallengedifficulty.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            int id = Convert.ToInt32(reader2["ChallengeID"]);

                            string difficulty = reader2["Schwierigkeitsbeschreibung"].ToString();

                            // Set category of challenge
                            for (int j = 0; j < challenges.Count; j++)
                            {
                                // For the correct id
                                if (id == challenges[j].id)
                                {
                                    challenges[j].difficulty = difficulty;
                                }
                            }

                        }
                    }
                }


                // Select every workout
                using (MySqlCommand getworkouts = new MySqlCommand($"SELECT * FROM `Workout`;", con))
                {
                    using (MySqlDataReader reader3 = getworkouts.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            int workoutId = Convert.ToInt32(reader3["WorkoutID"].ToString());
                            string workoutName = reader3["WorkoutName"].ToString();
                            int workoutDuration = Convert.ToInt32(reader3["WorkoutDauer"].ToString());
                            bool workoutLiked;
                            /*if (reader["Liked"].ToString() == "True")
                            {
                                liked = true;
                            }
                            else
                            {
                                liked = false;
                            }*/

                            byte[] workoutImgg = (byte[])(reader3["WorkoutBild"]);

                            // Create new workout
                            Workout workout = new Workout
                            {
                                id = workoutId,
                                WorkoutName = workoutName,
                                duration = workoutDuration,
                                difficulty = "",
                                //liked = workoutLiked,
                                Exercises = new List<Exercise>(),
                                WorkoutImage = workoutImgg,
                            };

                            // Set ingredients of recipe
                            for (int j = 0; j < challenges.Count; j++)
                            {
                                // For the correct id
                                if (workoutId == challenges[j].id)
                                {
                                    challenges[j].Workouts.Add(workout);
                                    workouts.Add(workout);
                                }
                            }

                        }
                    }
                }


                // Select every exercise
                using (MySqlCommand getexercises = new MySqlCommand($"SELECT * FROM `Übung`, `Workout_Übung` WHERE Übung.ÜbungID = Workout_Übung.ÜbungID;", con))
                {
                    // Execute the SQL query and get the result set
                    using (MySqlDataReader reader4 = getexercises.ExecuteReader())
                    {
                        // Iterate through each row of the result set
                        while (reader4.Read())
                        {
                            // Extract the exercise name from the current row
                            string exerciseName = reader4["ÜbungName"].ToString();

                            string sets = reader4["Sätze"].ToString();
                            string reps = reader4["Wiederholungen"].ToString();

                            // Extract the exercise ID from the current row and convert it to an int
                            int id = Convert.ToInt32(reader4["WorkoutID"]);

                            // Extract the exercise image from the current row
                            byte[] exerciseImgg = (byte[])(reader4["ÜbungGIF"]);

                            // Create a new Exercise object with the extracted information
                            Exercise exercise = new Exercise
                            {
                                ExerciseName = exerciseName,
                                ExerciseReps = "",
                                ExerciseSets = "",
                                ExerciseImage = exerciseImgg,
                            };

                            // Iterate through each workout in the list of workouts
                            for (int i = 0; i < challenges.Count; i++)
                            {
                                for (int j = 0; j < workouts.Count; j++)
                                {
                                    // Check if the current workout has the same ID as the current exercise
                                    if (id == workouts[j].id)
                                    {
                                        // Add the exercise to the current workout's list of exercises
                                        challenges[i].Workouts[j].Exercises.Add(exercise);
                                    }
                                }
                            }

                        }
                    }
                }

                // close connection
                con.Close();

                // Set FirstView's recipe to the recipes from database
                ChallengeOverviewViewController.challenges = null;
                ChallengeOverviewViewController.challenges = challenges;
            }
        }
    }
}

