// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Foundation;
using MySql.Data.MySqlClient;
using UIKit;

namespace YeahFit
{
    public partial class ChallengeViewController : UIViewController
    {
        public static MySqlConnection con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");

        public UINavigationController CurrentNavigationController;
        static Challenge nowSelectedChallenge;
        public static Challenge selectedChallenge;
        internal static List<Workout> internalWorkouts;
        static UITableView tableView;
        public static int index;
        public static bool liked;

        bool internalMonday;
        bool internalTuesday;
        bool internalWednesday;
        bool internalThursday;
        bool internalFriday;
        bool internalSaturday;
        bool internalSunday;

        public static ChallengeOverviewViewController firstViewController;


        public ChallengeViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void ViewDidLoad()
        {

            WorkoutViewController.challenge = true;
            WorkoutViewController.lastWorkouts = false;

            nowSelectedChallenge = ChallengeTableViewSource.nowSelectedChallenge;

            if (nowSelectedChallenge.liked == true)
            {
                imageView_LikeChallenge.Image = UIImage.GetSystemImage("heart.fill");
            }
            else
            {
                imageView_LikeChallenge.Image = UIImage.GetSystemImage("heart");
            }

            // Button click for liking the recipe
            btn_LikeChallenge.TouchUpInside += (sender, e) =>
            {
                // Set liked
                liked = nowSelectedChallenge.liked;

                // Like the recipe
                if (liked == false)
                {
                    nowSelectedChallenge.liked = true;

                    // open database connection
                    con.Open();

                    // Set Liked in database true
                    MySqlCommand like = new MySqlCommand($"UPDATE Challenge SET Liked = 1 WHERE ChallengeID = {nowSelectedChallenge.id};", con);
                    like.ExecuteNonQuery();

                    // Close connection
                    con.Close();

                    // Set filled heart image
                    imageView_LikeChallenge.Image = UIImage.GetSystemImage("heart.fill");
                }

                // Unlike the recipe
                else if (liked == true)
                {
                    nowSelectedChallenge.liked = false;

                    // open database connection
                    con.Open();

                    // Set Liked in database false
                    MySqlCommand like = new MySqlCommand($"UPDATE Challenge SET Liked = 0 WHERE ChallengeID = {nowSelectedChallenge.id};", con);
                    like.ExecuteNonQuery();

                    // Close connection
                    con.Close();

                    // Set heart image
                    imageView_LikeChallenge.Image = UIImage.GetSystemImage("heart");
                }

            };

            // If there's a recipe, load
            if (nowSelectedChallenge != null)
            {
                // Set internal Ingredients and Steps lists
                internalWorkouts = nowSelectedChallenge.Workouts;
                //internalSteps = nowSelectedRecipe.Steps;

                // Set general labels
                lbl_ChallengeName.Text = nowSelectedChallenge.ChallengeName;


                // Set button colors for showing ingredients or steps
                //btn_Ingredients.TintColor = UIColor.Tint;
                //btn_Steps.TintColor = UIColor.LightGray;

                // Set source for ingredient tableView
                tableView_Challenges.Source = new ChallengeWorkoutsTableViewSource(internalWorkouts, this, CurrentNavigationController);
                //tableView_Challenges.RowHeight = 71;

                // Reload ingredient tableView
                tableView_Challenges.ReloadData();



            }

            btn_Apply.TouchUpInside += (sender, e) =>
            {
                con.Open();
                string completeHardWorkout = $"UPDATE `Benutzer_Awards` SET `Starte eine Challenge` = `Starte eine Challenge` + 1 WHERE `BenutzerID` = {LoginViewController.userID};";
                MySqlCommand cmd = new MySqlCommand(completeHardWorkout, con);
                cmd.ExecuteNonQuery();
                con.Close();

                internalMonday = false;
                internalTuesday = false;
                internalWednesday = false;
                internalThursday = false;
                internalFriday = false;
                internalSaturday = false;
                internalSunday = false;

                for (int i = 0; i < internalWorkouts.Count; i++)
                {
                    switch (internalWorkouts[i].day)
                    {
                        case 1:
                            internalMonday = true;
                            break;
                        case 2:
                            internalTuesday = true;
                            break;
                        case 3:
                            internalWednesday = true;
                            break;
                        case 4:
                            internalThursday = true;
                            break;
                        case 5:
                            internalFriday = true;
                            break;
                        case 6:
                            internalSaturday = true;
                            break;
                        case 7:
                            internalSunday = true;
                            break;
                        default:
                            break;
                    }
                }

                Alert();
            };

        }

        void Alert()
        {
            if (LoginViewController.loggedin == false)
            {
                //Create Alert
                var okAlertController = UIAlertController.Create("Melde dich an", "Melde dich an, um deine Woche einstellen zu können.", UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(okAlertController, true, null);
            }
            else
            {
                //Create Alert
                var okCancelAlertController = UIAlertController.Create("Achtung", "Wenn du deine Woche änderst, geht der bisherige Fortschritt dieser Woche verloren.", UIAlertControllerStyle.Alert);

                //Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => SetWeek.SelectSetWeek(internalMonday, internalTuesday, internalWednesday, internalTuesday, internalFriday, internalSaturday, internalSunday)));
                okCancelAlertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Abbrechen")));

                //Present Alert
                PresentViewController(okCancelAlertController, true, null);
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
            this.DismissViewController(true, () => { ChallengeOverviewViewController.Refresh(firstViewController); });
        }

        /// <summary>
        /// View reappears
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            WorkoutViewController.challenge = true;
            WorkoutViewController.lastWorkouts = false;

            // Set internal recipe, ingredients list, steps list
            nowSelectedChallenge = ChallengeOverviewViewController.challenges[index];
            internalWorkouts = nowSelectedChallenge.Workouts;

            // Set general information
            lbl_ChallengeName.Text = nowSelectedChallenge.ChallengeName;


            // Set source for ingredient tableView
            tableView_Challenges.Source = new ChallengeWorkoutsTableViewSource(internalWorkouts, this, CurrentNavigationController);
            //tableView_Challenges.RowHeight = 71;

            // Reload ingredient tableView
            tableView_Challenges.ReloadData();
        }

        /// <summary>
        /// Refresh View
        /// </summary>
        /// <param name="recipeViewController"></param>
        /// <param name="image"></param>
        public static void Refresh(ChallengeViewController challengeViewController)
        {
            challengeViewController.ViewDidAppear(true);
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

            var WorkoutViewController = segue.DestinationViewController as WorkoutViewController;

            // Set edit true and setting recipe, index and RecipeViewController in SecondView
            /*WorkoutStepViewController.edit = true;
            WorkoutStepViewController.selectedRecipe = nowSelectedRecipe;
            WorkoutStepViewController.index = index;
            WorkoutStepViewController.recipeViewController = this;
            */
        }
    }
}