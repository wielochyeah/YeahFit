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
            // Create an empty list of challenges and workouts.
            challenges = new List<Challenge>();
            workouts = new List<Workout>();

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
                        int daysPerWeek = Convert.ToInt32(reader["DaysPerWeek"]);
                        if (reader["Liked"].ToString() == "True")
                        {
                            liked = true;
                        }
                        else
                        {
                            liked = false;
                        }

                        byte[] imgg = (byte[])(reader["ChallengeBild"]);

                        // Create new challenge
                        Challenge challenge = new Challenge
                        {
                            id = id,
                            ChallengeName = name,
                            difficulty = "",
                            liked = liked,
                            daysPerWeek = daysPerWeek,
                            Workouts = new List<Workout>(),
                            ChallengeImage = imgg,
                        };

                        // Add to challenges list
                        challenges.Add(challenge);
                    }
                }


                // Select every workout
                using (MySqlCommand getworkouts = new MySqlCommand($"SELECT * FROM `Workout`, `Challenge_Workout` " +
                    $"WHERE Workout.WorkoutID = Challenge_Workout.WorkoutID;", con))
                {
                    using (MySqlDataReader reader3 = getworkouts.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            int workoutId = Convert.ToInt32(reader3["WorkoutID"].ToString());
                            int challengeId = Convert.ToInt32(reader3["ChallengeID"].ToString());

                            string workoutName = reader3["WorkoutName"].ToString();
                            int workoutDuration = Convert.ToInt32(reader3["WorkoutDauer"].ToString());

                            int workoutDay = Convert.ToInt32(reader3["Wochentag"].ToString());

                            bool workoutLiked;
                            if (reader3["Liked"].ToString() == "1")
                            {
                                workoutLiked = true;
                            }
                            else
                            {
                                workoutLiked = false;
                            }

                            byte[] workoutImgg = (byte[])(reader3["WorkoutBild"]);

                            // Create new workout
                            Workout workout = new Workout
                            {
                                id = workoutId,
                                WorkoutName = workoutName,
                                duration = workoutDuration,
                                difficulty = "",
                                liked = workoutLiked,
                                Exercises = new List<Exercise>(),
                                WorkoutImage = workoutImgg,
                                day = workoutDay,
                            };

                            // Set ingredients of recipe
                            for (int j = 0; j < challenges.Count; j++)
                            {
                                // For the correct id
                                if (challengeId == challenges[j].id)
                                {
                                    challenges[j].Workouts.Add(workout);
                                    workouts.Add(workout);
                                }
                            }

                        }
                    }
                }

                using (MySqlCommand getworkoutcategories = new MySqlCommand($"SELECT * FROM `Workout_Kategorie`;", con))
                {
                    using (MySqlDataReader reader3 = getworkoutcategories.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            int id = Convert.ToInt32(reader3["WorkoutID"]);

                            // Breakfast
                            bool core;
                            if (reader3["Core"].ToString() == "True")
                            {
                                core = true;
                            }
                            else
                            {
                                core = false;
                            }
                            // Lunch
                            bool upperBody;
                            if (reader3["Oberkörper"].ToString() == "True")
                            {
                                upperBody = true;
                            }
                            else
                            {
                                upperBody = false;
                            }
                            // Dinner
                            bool fullBody;
                            if (reader3["Ganzkörper"].ToString() == "True")
                            {
                                fullBody = true;
                            }
                            else
                            {
                                fullBody = false;
                            }
                            // Dessert
                            bool push;
                            if (reader3["Push"].ToString() == "True")
                            {
                                push = true;
                            }
                            else
                            {
                                push = false;
                            }
                            // Snacks
                            bool pull;
                            if (reader3["Pull"].ToString() == "True")
                            {
                                pull = true;
                            }
                            else
                            {
                                pull = false;
                            }
                            // Vegetarian
                            bool twentyMinutes;
                            if (reader3["20min"].ToString() == "True")
                            {
                                twentyMinutes = true;
                            }
                            else
                            {
                                twentyMinutes = false;
                            }
                            // Vegan
                            bool noEquipment;
                            if (reader3["No Equipment"].ToString() == "True")
                            {
                                noEquipment = true;
                            }
                            else
                            {
                                noEquipment = false;
                            }
                            // Drinks
                            bool lowerBody;
                            if (reader3["Unterkörper"].ToString() == "True")
                            {
                                lowerBody = true;
                            }
                            else
                            {
                                lowerBody = false;
                            }

                            // Set category of recipe
                            for (int j = 0; j < workouts.Count; j++)
                            {
                                // For the correct id
                                if (id == workouts[j].id)
                                {
                                    workouts[j].core = core;
                                    workouts[j].upperBody = upperBody;
                                    workouts[j].lowerBody = lowerBody;
                                    workouts[j].fullBody = fullBody;
                                    workouts[j].push = push;
                                    workouts[j].pull = pull;
                                    workouts[j].twentyMinutes = twentyMinutes;
                                    workouts[j].noEquipment = noEquipment;
                                }
                            }

                        }
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


                // Select every exercise
                using (MySqlCommand getexercises = new MySqlCommand($"SELECT * FROM `Challenge`, `Challenge_Workout`, `Übung`, `Workout_Übung` " +
                    $"WHERE Übung.ÜbungID = Workout_Übung.ÜbungID " +
                    $"AND Challenge.ChallengeID = Challenge_Workout.ChallengeID " +
                    $"AND Challenge_Workout.WorkoutID = Workout_Übung.WorkoutID;", con))
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

                            // Extract the IDs from the current row and convert it to an int
                            int id = Convert.ToInt32(reader4["WorkoutID"]);
                            int challengeId = Convert.ToInt32(reader4["ChallengeID"]);

                            // Extract the exercise image from the current row
                            byte[] exerciseImgg = (byte[])(reader4["ÜbungGIF"]);

                            // Create a new Exercise object with the extracted information
                            Exercise exercise = new Exercise
                            {
                                ExerciseName = exerciseName,
                                ExerciseReps = reps,
                                ExerciseSets = sets,
                                ExerciseImage = exerciseImgg,
                            };

                            // Iterate through each workout in the list of workouts
                            for (int i = 0; i < challenges.Count; i++)
                            {
                                for (int j = 0; j < workouts.Count; j++)
                                {
                                    // Check if the current workout has the same ID as the current exercise
                                    if (id == workouts[j].id && challengeId == challenges[i].id)
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

