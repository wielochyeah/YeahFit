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

        // <summary>
        /// Initialize
        /// </summary>
        public static void Initialize()
        {
            workouts = new List<Workout>();

            // Open connection
            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();


            //
            // Filter
            //

            // Categories
            // Breakfast
            if (category == "core")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Core'";
            }
            // Lunch
            else if (category == "upperBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Oberkörper'";
            }
            // Dinner
            else if (category == "lowerBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Unterkörper'";
            }
            // Dessert
            else if (category == "fullBody")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Ganzkörper'";
            }
            // Snacks
            else if (category == "push")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Push'";
            }
            // Vegetarian
            else if (category == "pull")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = 'Pull'";
            }
            // Vegan
            else if (category == "twentyMinutes")
            {
                filter = ", `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    "WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    "AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    "AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID " +
                    "AND Kategorie.`KategorieName` = '20min'";
            }
            // Drinks
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
            // Professional
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

                        // Create new recipe
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

                        // Add to recipes list
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

                            // Set category of recipe
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
                using (MySqlCommand getrecipecategories = new MySqlCommand($"SELECT * FROM `Workout`, `Workout_Kategorie`, `Kategorie`, `Schwierigkeit` " +
                    $"WHERE Workout.`WorkoutID` = Workout_Kategorie.`WorkoutID` " +
                    $"AND Workout_Kategorie.`KategorieID` = Kategorie.`KategorieID` " +
                    $"AND Workout.SchwierigkeitsID = Schwierigkeit.SchwierigkeitsID;", con))
                {
                    using (MySqlDataReader reader3 = getrecipecategories.ExecuteReader())
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
                using (MySqlCommand getingredients = new MySqlCommand($"SELECT * FROM `Übung`, `Workout_Übung` WHERE Übung.ÜbungID = Workout_Übung.ÜbungID;", con))
                {
                    using (MySqlDataReader reader4 = getingredients.ExecuteReader())
                    {
                        while (reader4.Read())
                        {
                            string name = reader4["ÜbungName"].ToString();
                            //string sätze = reader4["Menge"].ToString();
                            //string
                            int id = Convert.ToInt32(reader4["WorkoutID"]);

                            byte[] imgg = (byte[])(reader4["ÜbungGIF"]);

                            // Create new exercise
                            Exercise exercise = new Exercise
                            {
                                ExerciseName = name,
                                ExerciseReps = "",
                                ExerciseSets = "",
                                ExerciseImage = imgg,
                            };

                            // Set ingredients of recipe
                            for (int j = 0; j < workouts.Count; j++)
                            {
                                // For the correct id
                                if (id == workouts[j].id)
                                {
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
                ChallengeOverviewViewController.workouts = null;
                ChallengeOverviewViewController.workouts = workouts;
            }
        }
    }
}

