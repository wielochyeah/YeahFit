using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace YeahFit
{
	public class InitializeChallenges
	{
        public static MySqlConnection con;
        public static List<Challenge> challenges = new List<Challenge>();
        public List<Workout> Workouts;
        //public List<Step> Steps;
        public static string category;
        public static string filter;
        public static string order = "LastAdded";
        public static string orderby;
        public static bool favourite;
        public static string difficulty;
        public static string search;

        public InitializeChallenges()
        {
        }

        // <summary>
        /// Initialize
        /// </summary>
        public static void Initialize()
        {
            challenges = new List<Challenge>();

            // Open connection
            con = new MySqlConnection(@"Server=localhost;Database=YeahCook;User Id=root;Password=; CharSet = utf8");
            con.Open();


            //
            // Filter
            //

            // Categories
            // Breakfast
            if (category == "breakfast")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Frühstück = 1";
            }
            // Lunch
            else if (category == "lunch")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Mittagessen = 1";
            }
            // Dinner
            else if (category == "dinner")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Abendessen = 1";
            }
            // Dessert
            else if (category == "dessert")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Dessert = 1";
            }
            // Snacks
            else if (category == "snacks")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Snacks = 1";
            }
            // Vegetarian
            else if (category == "vegetarian")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Vegetarisch = 1";
            }
            // Vegan
            else if (category == "vegan")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Vegan = 1";
            }
            // Drinks
            else if (category == "drinks")
            {
                filter = ", `RezeptKategorie` WHERE Rezept.RezeptID = RezeptKategorie.RezeptID AND RezeptKategorie.Getränk = 1";
            }
            else
            {
                filter = "";
            }


            // Order by

            // Last added
            if (order == "LastAdded")
            {
                orderby = " ORDER BY Rezept.RezeptID DESC";
            }
            // First added
            else if (order == "FirstAdded")
            {
                orderby = " ORDER BY Rezept.RezeptID ASC";
            }
            // Alphabetical ascending
            else if (order == "AlphAsc")
            {
                orderby = " ORDER BY Rezept.Name ASC";
            }
            // Alphabetical descending
            else if (order == "AlphDesc")
            {
                orderby = " ORDER BY Rezept.Name DESC";
            }
            // Duration ascending
            else if (order == "DurationAsc")
            {
                orderby = " ORDER BY Rezept.Dauer ASC";
            }
            // Duration descending
            else if (order == "DurationDesc")
            {
                orderby = " ORDER BY Rezept.Dauer DESC";
            }


            // Favourite/Liked
            if (favourite == true)
            {
                if (filter == "")
                {
                    filter = " WHERE Rezept.Liked = 1";
                }
                else
                {
                    filter = filter + " AND Rezept.Liked = 1";
                }
            }

            // Difficulty
            // Beginner
            if (difficulty == "beginner")
            {
                if (filter == "")
                {
                    filter = " WHERE Rezept.Schwierigkeit = 'beginner'";
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
                    filter = " WHERE Rezept.Schwierigkeit = 'advanced'";
                }
                else
                {
                    filter = filter + " AND Rezept.Schwierigkeit = 'advanced'";
                }
            }
            // Professional
            else if (difficulty == "professional")
            {
                if (filter == "")
                {
                    filter = " WHERE Rezept.Schwierigkeit = 'professional'";
                }
                else
                {
                    filter = filter + " AND Rezept.Schwierigkeit = 'professional'";
                }
            }

            // Searchbar
            if (search != "" && search != null)
            {
                if (filter == "")
                {
                    filter = $" WHERE Rezept.Name LIKE '%{search}%'";
                }
                else
                {
                    filter = filter + $" AND Rezept.Name LIKE '%{search}%'";
                }
            }

            // Read every recipe
            //  + filter
            //  + orderby
            using (MySqlCommand getmainrecipe = new MySqlCommand($"SELECT * FROM `Rezept` {filter} {orderby}", con))
            {
                using (MySqlDataReader reader = getmainrecipe.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        int id = Convert.ToInt32(reader["RezeptID"].ToString());
                        string name = reader["Name"].ToString();
                        string beschreibung = reader["Beschreibung"].ToString();
                        int dauer = Convert.ToInt32(reader["Dauer"].ToString());
                        bool liked;
                        if (reader["Liked"].ToString() == "True")
                        {
                            liked = true;
                        }
                        else
                        {
                            liked = false;
                        }
                        string schwierigkeit = reader["Schwierigkeit"].ToString();

                        byte[] imgg = (byte[])(reader["Bild"]);

                        // Create new recipe
                        Challenge challenge = new Challenge
                        {
                            id = id,
                            RecipeName = name,
                            RecipeInfo = beschreibung,
                            duration = dauer,
                            difficulty = schwierigkeit,
                            liked = liked,
                            Workouts = new List<Workout>(),
                            //Steps = new List<Step>(),
                            RecipeImage = imgg,
                        };

                        // Add to recipes list
                        challenges.Add(challenge);
                    }
                }

                // Get every category
                using (MySqlCommand getrecipecategories = new MySqlCommand($"SELECT * FROM `RezeptKategorie`;", con))
                {
                    using (MySqlDataReader reader2 = getrecipecategories.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            int id = Convert.ToInt32(reader2["RezeptID"]);

                            // Breakfast
                            bool breakfast;
                            if (reader2["Frühstück"].ToString() == "True")
                            {
                                breakfast = true;
                            }
                            else
                            {
                                breakfast = false;
                            }
                            // Lunch
                            bool lunch;
                            if (reader2["Mittagessen"].ToString() == "True")
                            {
                                lunch = true;
                            }
                            else
                            {
                                lunch = false;
                            }
                            // Dinner
                            bool dinner;
                            if (reader2["Abendessen"].ToString() == "True")
                            {
                                dinner = true;
                            }
                            else
                            {
                                dinner = false;
                            }
                            // Dessert
                            bool dessert;
                            if (reader2["Dessert"].ToString() == "True")
                            {
                                dessert = true;
                            }
                            else
                            {
                                dessert = false;
                            }
                            // Snacks
                            bool snacks;
                            if (reader2["Snacks"].ToString() == "True")
                            {
                                snacks = true;
                            }
                            else
                            {
                                snacks = false;
                            }
                            // Vegetarian
                            bool vegetarisch;
                            if (reader2["Vegetarisch"].ToString() == "True")
                            {
                                vegetarisch = true;
                            }
                            else
                            {
                                vegetarisch = false;
                            }
                            // Vegan
                            bool vegan;
                            if (reader2["Vegan"].ToString() == "True")
                            {
                                vegan = true;
                            }
                            else
                            {
                                vegan = false;
                            }
                            // Drinks
                            bool drinks;
                            if (reader2["Getränk"].ToString() == "True")
                            {
                                drinks = true;
                            }
                            else
                            {
                                drinks = false;
                            }

                            // Set category of recipe
                            for (int j = 0; j < challenges.Count; j++)
                            {
                                // For the correct id
                                if (id == challenges[j].id)
                                {
                                    challenges[j].breakfast = breakfast;
                                    challenges[j].lunch = lunch;
                                    challenges[j].dinner = dinner;
                                    challenges[j].dessert = dessert;
                                    challenges[j].snacks = snacks;
                                    challenges[j].vegetarian = vegetarisch;
                                    challenges[j].vegan = vegan;
                                    challenges[j].drinks = drinks;
                                }
                            }

                        }
                    }
                }

                // Select every ingredient
                using (MySqlCommand getingredients = new MySqlCommand($"SELECT * FROM `Zutat`;", con))
                {
                    using (MySqlDataReader reader3 = getingredients.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            string name = reader3["Zutat"].ToString();
                            string ammount = reader3["Menge"].ToString();
                            int id = Convert.ToInt32(reader3["RezeptID"]);

                            Workout workout = new Workout
                            {
                                WorkoutName = name,
                            };

                            // Set ingredients of recipe
                            for (int j = 0; j < challenges.Count; j++)
                            {
                                // For the correct id
                                if (id == challenges[j].id)
                                {
                                    challenges[j].Workouts.Add(workout);
                                }
                            }

                        }
                    }
                }

                // Select every step
                using (MySqlCommand getsteps = new MySqlCommand($"SELECT * FROM `Schritt`;", con))
                {
                    using (MySqlDataReader reader4 = getsteps.ExecuteReader())
                    {
                        while (reader4.Read())
                        {
                            string stepinfo = reader4["Schritt"].ToString();
                            int id = Convert.ToInt32(reader4["RezeptID"]);

                            // Create new steo
                            /*Step step = new Step
                            {
                                StepInfo = stepinfo,
                            };

                            // Set steps of recipe
                            for (int j = 0; j < workouts.Count; j++)
                            {
                                // For the correct id
                                if (id == workouts[j].id)
                                {
                                    workouts[j].Steps.Add(step);
                                }
                            }*/
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

