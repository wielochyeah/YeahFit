// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using MySql.Data.MySqlClient;
using UIKit;

namespace YeahFit
{
	public partial class WorkoutViewController : UIViewController
	{
        public static MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=YeahCook;User Id=root;Password=; CharSet = utf8");

        static Workout nowSelectedWorkout;
        public static Workout selectedWorkout;
        //internal static List<Step> internalSteps;
        //internal static List<Ingredient> internalIngredients;
        static UITableView tableView;
        public static int index;
        public static bool liked;

        public static WorkoutOverviewViewController firstViewController;


        public WorkoutViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Initialize
        /// </summary>
		/*public override void ViewDidLoad()
        {
            nowSelectedWorkout = WorkoutTableViewSource.nowSelectedWorkout;

            // If there's a recipe, load
            if (nowSelectedWorkout != null)
            {
                // Set internal Ingredients and Steps lists
                //internalIngredients = nowSelectedRecipe.Ingredients;
                //internalSteps = nowSelectedRecipe.Steps;

                // Set general labels
                lbl_WorkoutName.Text = nowSelectedWorkout.RecipeName;
                lbl_WorkoutInfo.Text = nowSelectedWorkout.RecipeInfo;

                // Set difficulty
                if (nowSelectedWorkout.difficulty == "beginner")
                {
                    lbl_WorkoutDifficulty.Text = "   Anfänger";
                }
                else if (nowSelectedWorkout.difficulty == "advanced")
                {
                    lbl_WorkoutDifficulty.Text = "Fortgeschritten";
                }
                else if (nowSelectedWorkout.difficulty == "professional")
                {
                    lbl_WorkoutDifficulty.Text = "       Profi";
                }

                // Set duration
                TimeSpan duration = TimeSpan.FromSeconds(nowSelectedWorkout.duration);
                lbl_WorkoutDuration.Text = duration.ToString(@"hh\:mm");

                // Set image
                var data = NSData.FromArray(nowSelectedWorkout.RecipeImage);
                UIImage image = UIImage.LoadFromData(data);

                imageView_WorkoutImage.Image = image;

                // Set button colors for showing ingredients or steps
                //btn_Ingredients.TintColor = UIColor.Tint;
                //btn_Steps.TintColor = UIColor.LightGray;

                // Set source for ingredient tableView
                tableView_RecipeView.Source = new RecipeViewIngredientsSource(internalIngredients);
                tableView_RecipeView.RowHeight = 71;

                // Reload ingredient tableView
                tableView_RecipeView.ReloadData();


                // Button click for showing ingredient table view
                btn_Ingredients.TouchUpInside += (sender, e) =>
                {
                    // Set button colors for showing ingredients or steps
                    btn_Ingredients.TintColor = UIColor.Tint;
                    btn_Steps.TintColor = UIColor.LightGray;

                    // Set source
                    tableView_RecipeView.Source = new RecipeViewIngredientsSource(internalIngredients);
                    tableView_RecipeView.RowHeight = 71;

                    // Reload
                    tableView_RecipeView.ReloadData();
                };

                // Button click for showing steps table view
                btn_Steps.TouchUpInside += (sender, e) =>
                {
                    // Set button colors for showing ingredients or steps
                    btn_Ingredients.TintColor = UIColor.LightGray;
                    btn_Steps.TintColor = UIColor.Tint;

                    // Set source
                    tableView_RecipeView.Source = new RecipeViewStepsSource(internalSteps);
                    tableView_RecipeView.RowHeight = UITableView.AutomaticDimension;
                    tableView_RecipeView.EstimatedRowHeight = 71f;

                    // Reload
                    tableView_RecipeView.ReloadData();
                };

                // Set liked
                liked = nowSelectedRecipe.liked;
                if (liked == false)
                {
                    liked = false;
                    imageView_Like.Image = UIImage.GetSystemImage("heart");
                }
                else if (liked == true)
                {
                    imageView_Like.Image = UIImage.GetSystemImage("heart.fill");
                }

                // Button click for liking the recipe
                btn_LikeRecipe.TouchUpInside += (sender, e) =>
                {
                    // Set liked
                    liked = nowSelectedRecipe.liked;

                    // Like the recipe
                    if (liked == false)
                    {
                        nowSelectedRecipe.liked = true;

                        // open database connection
                        con.Open();

                        // Set Liked in database true
                        MySqlCommand like = new MySqlCommand($"UPDATE Rezept SET Liked = 1 WHERE RezeptID = {nowSelectedRecipe.id};", con);
                        like.ExecuteNonQuery();

                        // Close connection
                        con.Close();

                        // Set filled heart image
                        imageView_Like.Image = UIImage.GetSystemImage("heart.fill");
                    }

                    // Unlike the recipe
                    else if (liked == true)
                    {
                        nowSelectedRecipe.liked = false;

                        // open database connection
                        con.Open();

                        // Set Liked in database false
                        MySqlCommand like = new MySqlCommand($"UPDATE Rezept SET Liked = 0 WHERE RezeptID = {nowSelectedRecipe.id};", con);
                        like.ExecuteNonQuery();

                        // Close connection
                        con.Close();

                        // Set heart image
                        imageView_Like.Image = UIImage.GetSystemImage("heart");
                    }

                };

                // Button click for deleting the recipe
                btn_Cart.TouchUpInside += (sender, e) =>
                {
                    // User can't delete the recipe if there's only one
                    if (index < FirstViewController.recipes.Count && FirstViewController.recipes.Count > 1)
                    {
                        // Remove recipe in recipes list
                        FirstViewController.recipes.RemoveAt(index);

                        // Set id
                        int deleteid = nowSelectedRecipe.id;

                        // Open connection
                        con.Open();

                        // Delete recipe from database
                        MySqlCommand deleterecipe = new MySqlCommand(
                            $"DELETE FROM Rezept WHERE RezeptID = {deleteid};" +
                            $"\nDELETE FROM RezeptKategorie WHERE RezeptID = {deleteid};" +
                            $"\nDELETE FROM Schritt WHERE RezeptID = {deleteid};" +
                            $"\nDELETE FROM Zutat WHERE RezeptID = {deleteid};", con);
                        deleterecipe.ExecuteNonQuery();

                        // Setting the id of every recipe with a higher id - 1
                        using (new MySqlCommand($"SELECT * from Rezept WHERE RezeptID > {deleteid}", con))
                        {
                            using (MySqlCommand sortrecipe = new MySqlCommand($"UPDATE Rezept SET RezeptID= RezeptID - 1 WHERE RezeptID > {deleteid};", con))
                            {
                                sortrecipe.ExecuteNonQuery();
                            }
                        }

                        using (new MySqlCommand($"SELECT * from RezeptKategorie WHERE RezeptID > {deleteid}", con))
                        {
                            using (MySqlCommand sortrecipecategory = new MySqlCommand($"UPDATE RezeptKategorie SET RezeptID= RezeptID - 1 WHERE RezeptID > {deleteid};", con))
                            {
                                sortrecipecategory.ExecuteNonQuery();
                            }
                        }


                        using (new MySqlCommand($"SELECT * from Zutat WHERE RezeptID > {deleteid}", con))
                        {
                            using (MySqlCommand sortingredient = new MySqlCommand($"UPDATE Zutat SET RezeptID= RezeptID - 1 WHERE RezeptID > {deleteid};", con))
                            {
                                sortingredient.ExecuteNonQuery();
                            }
                        }

                        using (new MySqlCommand($"SELECT * from Schritt WHERE RezeptID > {deleteid}", con))
                        {
                            using (MySqlCommand sortingredient = new MySqlCommand($"UPDATE Schritt SET RezeptID= RezeptID - 1 WHERE RezeptID > {deleteid};", con))
                            {
                                sortingredient.ExecuteNonQuery();
                            }
                        }

                        // Close connection
                        con.Close();

                        // Go back to FirstView
                        this.DismissViewController(true, () => { FirstViewController.Refresh(firstViewController); });
                    }
                };
            }

        }

        /// <summary>
        /// Reload FirstView if user swipes down the View
        /// + Set edit in SecondView false
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            SecondViewController.edit = false;
            this.DismissViewController(true, () => { FirstViewController.Refresh(firstViewController); });
        }

        /// <summary>
        /// View reappears
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Set internal recipe, ingredients list, steps list
            nowSelectedRecipe = FirstViewController.recipes[index];
            internalIngredients = nowSelectedRecipe.Ingredients;
            internalSteps = nowSelectedRecipe.Steps;

            // Set general information
            lbl_RecipeName.Text = nowSelectedRecipe.RecipeName;
            lbl_RecipeInfo.Text = nowSelectedRecipe.RecipeInfo;

            // Set difficulty
            if (nowSelectedRecipe.difficulty == "beginner")
            {
                lbl_RecipeDifficulty.Text = "   Anfänger";
            }
            else if (nowSelectedRecipe.difficulty == "advanced")
            {
                lbl_RecipeDifficulty.Text = "Fortgeschritten";
            }
            else if (nowSelectedRecipe.difficulty == "professional")
            {
                lbl_RecipeDifficulty.Text = "       Profi";
            }

            // Set duration
            TimeSpan duration = TimeSpan.FromSeconds(nowSelectedRecipe.duration);
            lbl_RecipeDuration.Text = duration.ToString(@"hh\:mm");

            // Set image
            var data = NSData.FromArray(nowSelectedRecipe.RecipeImage);
            UIImage image = UIImage.LoadFromData(data);

            imageView_RecipeImage.Image = image;

            // Set button colors for showing ingredients or steps
            btn_Ingredients.TintColor = UIColor.Tint;
            btn_Steps.TintColor = UIColor.LightGray;

            // Set source for ingredient tableView
            tableView_RecipeView.Source = new RecipeViewIngredientsSource(internalIngredients);
            tableView_RecipeView.RowHeight = 71;

            // Reload ingredient tableView
            tableView_RecipeView.ReloadData();

            // Button click for showing ingredient table view
            btn_Ingredients.TouchUpInside += (sender, e) =>
            {
                // Set button colors for showing ingredients or steps
                btn_Ingredients.TintColor = UIColor.Tint;
                btn_Steps.TintColor = UIColor.LightGray;

                // Set source
                tableView_RecipeView.Source = new RecipeViewIngredientsSource(internalIngredients);
                tableView_RecipeView.RowHeight = 71;

                // Reload
                tableView_RecipeView.ReloadData();
            };

            // Button click for showing steps table view
            btn_Steps.TouchUpInside += (sender, e) =>
            {
                // Set button colors for showing ingredients or steps
                btn_Ingredients.TintColor = UIColor.LightGray;
                btn_Steps.TintColor = UIColor.Tint;

                // Set source
                tableView_RecipeView.Source = new RecipeViewStepsSource(internalSteps);
                tableView_RecipeView.RowHeight = UITableView.AutomaticDimension;
                tableView_RecipeView.EstimatedRowHeight = 71f;

                // Reload
                tableView_RecipeView.ReloadData();
            };
        }

        /// <summary>
        /// Refresh View
        /// </summary>
        /// <param name="recipeViewController"></param>
        /// <param name="image"></param>
        public static void Refresh(RecipeViewController recipeViewController, byte[] image)
        {
            recipeViewController.ViewDidAppear(true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /// <summary>
        /// Prepare for showing SecondView for editing recipe
        /// </summary>
        /// <param name="segue"></param>
        /// <param name="sender"></param>
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var SecondViewController = segue.DestinationViewController as SecondViewController;

            // Set edit true and setting recipe, index and RecipeViewController in SecondView
            SecondViewController.edit = true;
            SecondViewController.selectedRecipe = nowSelectedRecipe;
            SecondViewController.index = index;
            SecondViewController.recipeViewController = this;
        }*/
    }
}
