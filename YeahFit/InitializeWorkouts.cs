using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace YeahFit
{
	public class InitializeWorkouts
	{

        public static MySqlConnection con;
        public static List<Workout> workouts = new List<Workout>();
        public List<Exercise> Exercises;
        public static string category;
        public static string filter;
        public static string order = "LastAdded";
        public static string orderby;
        public static bool favourite;
        public static string difficulty;
        public static string search;

        public InitializeWorkouts()
		{
		}

        /// <summary>
        /// This method initializes the list of workouts with different filtering and ordering options.
        /// </summary>
        public static void Initialize()
        {
            // Create an empty list of workouts.
            workouts = new List<Workout>();

            // Open a connection to the YeahFit database on the local server with the root user and empty password.
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();


            //
            // Filter the workouts based on the selected category.
            // Generate a filter string based on the user's category selection
            //

            // Categories
            // Core
            if (category == "core")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Core'";
            }
            // UpperBody
            else if (category == "upperBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Oberkörper'";
            }
            // LowerBody
            else if (category == "lowerBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Unterkörper'";
            }
            // FullBody
            else if (category == "fullBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Ganzkörper'";
            }
            // Push
            else if (category == "push")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Push'";
            }
            // Pull
            else if (category == "pull")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Pull'";
            }
            // TwentyMinutes
            else if (category == "twentyMinutes")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = '20min'";
            }
            // NoEquipment
            else if (category == "noEquipment")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'No Equipment'";
            }
            else
            {
                filter = "";
            }


            // Order by

            // Last added
            if (order == "LastAdded")
            {
                orderby = " ORDER BY Workout.WorkoutID DESC";
            }
            // First added
            else if (order == "FirstAdded")
            {
                orderby = " ORDER BY Workout.WorkoutID ASC";
            }
            // Alphabetical ascending
            else if (order == "AlphAsc")
            {
                orderby = " ORDER BY Workout.WorkoutName ASC";
            }
            // Alphabetical descending
            else if (order == "AlphDesc")
            {
                orderby = " ORDER BY Workout.WorkoutName DESC";
            }
            // Duration ascending
            else if (order == "DurationAsc")
            {
                orderby = " ORDER BY Workout.WorkoutDauer ASC";
            }
            // Duration descending
            else if (order == "DurationDesc")
            {
                orderby = " ORDER BY Workout.WorkoutDauer DESC";
            }


            // Favourite/Liked
            /*if (favourite == true)
            {
                if (filter == "")
                {
                    filter = " WHERE Workout.Liked = 1";
                }
                else
                {
                    filter = filter + " AND Workout.Liked = 1";
                }
            }*/

            // Difficulty
            // Beginner
            if (difficulty == "beginner")
            {
                if (filter == "")
                {
                    filter = ", Schwierigkeit " +
                        "WHERE Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                        "AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Beginner'";
                }
                else
                {
                    filter = filter + " AND Schwierigkeit.Schwierigkeitsbeschreibung = 'Beginner'";
                }
            }
            // Advanced
            else if (difficulty == "advanced")
            {
                if (filter == "")
                {
                    filter = ", Schwierigkeit " +
                        "WHERE Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
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
                        "WHERE Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
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
                    filter = $" WHERE Workout.WorkoutName LIKE '%{search}%'";
                }
                else
                {
                    filter = filter + $" AND Workout.WorkoutName LIKE '%{search}%'";
                }
            }

            // Read every workout
            //  + filter
            //  + orderby
            using (MySqlCommand getmainworkout = new MySqlCommand($"SELECT * FROM `Workout` {filter} {orderby}", con))
            {
                using (MySqlDataReader reader = getmainworkout.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int id = Convert.ToInt32(reader["WorkoutID"].ToString());
                        string name = reader["WorkoutName"].ToString();
                        int duration = Convert.ToInt32(reader["WorkoutDauer"].ToString());
                        bool liked;
                        /*if (reader["Liked"].ToString() == "True")
                        {
                            liked = true;
                        }
                        else
                        {
                            liked = false;
                        }*/

                        byte[] imgg = (byte[])(reader["WorkoutBild"]);

                        // Create new workout
                        Workout workout = new Workout
                        {
                            id = id,
                            WorkoutName = name,
                            duration = duration,
                            difficulty = "",
                            //liked = liked,
                            Exercises = new List<Exercise>(),
                            WorkoutImage = imgg,
                        };

                        // Add to workouts list
                        workouts.Add(workout);
                    }
                }


                // Get difficutly
                using (MySqlCommand getworkoutdifficulty = new MySqlCommand($"SELECT * FROM `Workout`, `Schwierigkeit` " +
                    $"WHERE Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID;", con))
                {
                    using (MySqlDataReader reader2 = getworkoutdifficulty.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            int id = Convert.ToInt32(reader2["WorkoutID"]);

                            string difficulty = reader2["Schwierigkeitsbeschreibung"].ToString();

                            // Set category of workout
                            for (int j = 0; j < workouts.Count; j++)
                            {
                                // For the correct id
                                if (id == workouts[j].id)
                                {
                                    workouts[j].difficulty = difficulty;
                                }
                            }

                        }
                    }
                }

                // Get every category
                using (MySqlCommand getworkoutcategories = new MySqlCommand($"SELECT * FROM `Workout`, `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    $"WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    $"AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    $"AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID;", con))
                {
                    using (MySqlDataReader reader3 = getworkoutcategories.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            int id = Convert.ToInt32(reader3["WorkoutID"]);

                            // core
                            bool core;
                            if (reader3["KategorieID"].ToString() == "1")
                            {
                                core = true;
                            }
                            else
                            {
                                core = false;
                            }
                            // upperBody
                            bool upperBody;
                            if (reader3["KategorieID"].ToString() == "2")
                            {
                                upperBody = true;
                            }
                            else
                            {
                                upperBody = false;
                            }
                            // lowerBody
                            bool lowerBody;
                            if (reader3["KategorieID"].ToString() == "3")
                            {
                                lowerBody = true;
                            }
                            else
                            {
                                lowerBody = false;
                            }
                            // fullBody
                            bool fullBody;
                            if (reader3["KategorieID"].ToString() == "4")
                            {
                                fullBody = true;
                            }
                            else
                            {
                                fullBody = false;
                            }
                            // push
                            bool push;
                            if (reader3["KategorieID"].ToString() == "5")
                            {
                                push = true;
                            }
                            else
                            {
                                push = false;
                            }
                            // pull
                            bool pull;
                            if (reader3["KategorieID"].ToString() == "6")
                            {
                                pull = true;
                            }
                            else
                            {
                                pull = false;
                            }
                            // twentyMinutes
                            bool twentyMinutes;
                            if (reader3["KategorieID"].ToString() == "7")
                            {
                                twentyMinutes = true;
                            }
                            else
                            {
                                twentyMinutes = false;
                            }
                            // noEquipment
                            bool noEquipment;
                            if (reader3["KategorieID"].ToString() == "8")
                            {
                                noEquipment = true;
                            }
                            else
                            {
                                noEquipment = false;
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
                            string name = reader4["ÜbungName"].ToString();

                            //string sätze = reader4["Menge"].ToString();
                            //string

                            // Extract the exercise ID from the current row and convert it to an int
                            int id = Convert.ToInt32(reader4["WorkoutID"]);

                            // Extract the exercise image from the current row
                            byte[] imgg = (byte[])(reader4["ÜbungGIF"]);

                            // Create a new Exercise object with the extracted information
                            Exercise exercise = new Exercise
                            {
                                ExerciseName = name,
                                ExerciseReps = "",
                                ExerciseSets = "",
                                ExerciseImage = imgg,
                            };

                            // Iterate through each workout in the list of workouts
                            for (int j = 0; j < workouts.Count; j++)
                            {
                                // Check if the current workout has the same ID as the current exercise
                                if (id == workouts[j].id)
                                {
                                    // Add the exercise to the current workout's list of exercises
                                    workouts[j].Exercises.Add(exercise);
                                }
                            }

                        }
                    }
                }

                // close connection
                con.Close();

                // Set FirstView's recipe to the recipes from database
                WorkoutOverviewViewController.workouts = null;
                WorkoutOverviewViewController.workouts = workouts;
                //ChallengeOverviewViewController.workouts = null;
                //ChallengeOverviewViewController.workouts = workouts;
            }
        }
    }
}

