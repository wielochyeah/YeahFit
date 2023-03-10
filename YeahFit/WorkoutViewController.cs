// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
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
        internal static List<Exercise> internalExercises;
        static UITableView tableView;
        public static int index;
        public static bool liked;

        public static WorkoutOverviewViewController firstViewController;
        public static ChallengeOverviewViewController secondViewController;



        public WorkoutViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Initialize
        /// </summary>
		public override void ViewDidLoad()
        {
            nowSelectedWorkout = WorkoutTableViewSource.nowSelectedWorkout;

            // If there's a recipe, load
            if (nowSelectedWorkout != null)
            {
                // Set internal Ingredients and Steps lists
                internalExercises = nowSelectedWorkout.Exercises;
                //internalSteps = nowSelectedRecipe.Steps;

                // Set general labels
                lbl_WorkoutName.Text = nowSelectedWorkout.WorkoutName;

                // Set difficulty
                if (nowSelectedWorkout.difficulty == "Beginner")
                {
                    lbl_difficulty.Text = "Beginner";
                }
                else if (nowSelectedWorkout.difficulty == "Fortgeschritten")
                {
                    lbl_difficulty.Text = "Fortgeschritten";
                }
                else if (nowSelectedWorkout.difficulty == "Hart")
                {
                    lbl_difficulty.Text = "Hart";
                }


                lbl_category.Text = "";

                if (nowSelectedWorkout.core == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Core";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Core";
                    }
                }

                // Category: Lunch
                if (nowSelectedWorkout.upperBody == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Oberkörper";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Oberkörper";
                    }
                }

                // Category: Dinner
                if (nowSelectedWorkout.lowerBody == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Unterkörper";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Unterkörper";
                    }
                }

                // Category: Dessert
                if (nowSelectedWorkout.fullBody == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Ganzkörper";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Ganzkörper";
                    }
                }

                // Category: Snacks
                if (nowSelectedWorkout.push == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Push";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Push";
                    }
                }

                // Category: Drinks
                if (nowSelectedWorkout.pull == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Pull";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Pull";
                    }
                }

                // Category: Vegetarian
                if (nowSelectedWorkout.twentyMinutes == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", 20 Minuten";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "20 Minuten";
                    }
                }

                // Category: Vegan
                if (nowSelectedWorkout.noEquipment == true)
                {
                    // If there were categories set before
                    if (lbl_category.Text != "")
                    {
                        // Set category text
                        lbl_category.Text = lbl_category.Text + ", Ohne Geräte";
                    }
                    else
                    {
                        // Set category text
                        lbl_category.Text = "Ohne Geräte";
                    }
                }

                // Set duration
                TimeSpan duration = TimeSpan.FromSeconds(nowSelectedWorkout.duration);
                lbl_duration.Text = duration.ToString(@"hh\:mm");

                // Set image
                var data = NSData.FromArray(nowSelectedWorkout.WorkoutImage);
                UIImage image = UIImage.LoadFromData(data);

                imageView_Workout.Image = image;

                // Set button colors for showing ingredients or steps
                //btn_Ingredients.TintColor = UIColor.Tint;
                //btn_Steps.TintColor = UIColor.LightGray;

                // Set source for ingredient tableView
                tableView_Exercises.Source = new ExerciseTableViewSource(internalExercises);
                tableView_Exercises.RowHeight = 71;

                // Reload ingredient tableView
                tableView_Exercises.ReloadData();
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
            if (firstViewController != null)
            {
                this.DismissViewController(true, () => { WorkoutOverviewViewController.Refresh(firstViewController); });
            }
            else
            {
                this.DismissViewController(true, () => { ChallengeOverviewViewController.Refresh(secondViewController); });
            }
        }

        /// <summary>
        /// View reappears
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Set internal recipe, ingredients list, steps list
            if (WorkoutOverviewViewController.workouts[index] != null)

            {
                nowSelectedWorkout = WorkoutOverviewViewController.workouts[index];
            }
            else
            {
                //nowSelectedWorkout = ChallengeOverviewViewController.workouts[index];
            }
            internalExercises = nowSelectedWorkout.Exercises;

            // Set general information
            lbl_WorkoutName.Text = nowSelectedWorkout.WorkoutName;

            // Set difficulty
            if (nowSelectedWorkout.difficulty == "beginner")
            {
                lbl_difficulty.Text = "Beginner";
            }
            else if (nowSelectedWorkout.difficulty == "advanced")
            {
                lbl_difficulty.Text = "Fortgeschritten";
            }
            else if (nowSelectedWorkout.difficulty == "professional")
            {
                lbl_difficulty.Text = "Profi";
            }

            // Set duration
            TimeSpan duration = TimeSpan.FromSeconds(nowSelectedWorkout.duration);
            lbl_duration.Text = duration.ToString(@"hh\:mm") + " Stunden";

            // Set image
            var data = NSData.FromArray(nowSelectedWorkout.WorkoutImage);
            UIImage image = UIImage.LoadFromData(data);

            imageView_Workout.Image = image;

            

            // Set source for ingredient tableView
            tableView_Exercises.Source = new ExerciseTableViewSource(internalExercises);
            tableView_Exercises.RowHeight = 71;

            // Reload ingredient tableView
            tableView_Exercises.ReloadData();

            
        }

        /// <summary>
        /// Refresh View
        /// </summary>
        /// <param name="recipeViewController"></param>
        /// <param name="image"></param>
        public static void Refresh(WorkoutViewController workoutViewController, byte[] image)
        {
            workoutViewController.ViewDidAppear(true);
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

            var WorkoutStepViewController = segue.DestinationViewController as WorkoutStepViewController;

            // Set edit true and setting recipe, index and RecipeViewController in SecondView
            WorkoutStepViewController.selectedWorkout = nowSelectedWorkout;
            WorkoutStepViewController.index = index;
            //WorkoutStepViewController.workoutViewController = this;
        }
    }
}
