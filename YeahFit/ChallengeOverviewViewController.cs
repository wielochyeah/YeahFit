// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using MySql.Data.MySqlClient;
using UIKit;
using System.Drawing;

namespace YeahFit
{
	public partial class ChallengeOverviewViewController : UIViewController
	{
        public UINavigationController CurrentNavigationController;

        // Main list of all recipes
        public static List<Challenge> challenges;
        public static List<Workout> workouts;


        public ChallengeOverviewViewController(IntPtr handle) : base(handle)
        {
        }


        /// <summary>
        /// Initialization of the main view 'FirstView'
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.



            // Buttons for setting categories
            /*btn_Breakfast.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "breakfast")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "breakfast";
                }
                ViewDidAppear(true);
            };
            btn_Lunch.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "lunch")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "lunch";
                }
                ViewDidAppear(true);
            };
            btn_Dinner.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "dinner")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "dinner";
                }
                ViewDidAppear(true);
            };
            btn_Dessert.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "dessert")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "dessert";
                }
                ViewDidAppear(true);
            };
            btn_Snacks.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "snacks")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "snacks";
                }
                ViewDidAppear(true);
            };
            btn_Vegan.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "vegan")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "vegan";
                }
                ViewDidAppear(true);
            };
            btn_Vegetarian.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "vegetarian")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "vegetarian";
                }
                ViewDidAppear(true);
            };
            btn_Drinks.TouchUpInside += (sender, e) =>
            {
                if (InitializeRecipes.category == "drinks")
                {
                    InitializeRecipes.category = "";
                }
                else
                {
                    InitializeRecipes.category = "drinks";
                }
                ViewDidAppear(true);
            };

            // Button for showing the FilterView
            btn_Filter.TouchUpInside += (sender, e) =>
            {
                FilterViewController.firstViewController = this;
            };
            */
            // Loading the tableView
            ChallengeViewController.firstViewController = this;
            WorkoutViewController.secondViewController = this;
            challenges = null;
            workouts = null;

            // Get data from database
            InitializeChallenges.Initialize();
            InitializeWorkouts.Initialize();

            // Setting recipes as its source
            tableView_ChallengeOverview.Source = new ChallengeTableViewSource(challenges, this, CurrentNavigationController);
            tableView_ChallengeOverview.RowHeight = 195;

            // Reload tableView
            tableView_ChallengeOverview.ReloadData();

        }

        /// <summary>
        /// Reload tabeView_Recipes after view reappeared
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ChallengeViewController.firstViewController = this;
            challenges = null;
            InitializeChallenges.Initialize();
            tableView_ChallengeOverview.Source = new ChallengeTableViewSource(challenges, this, CurrentNavigationController);
            tableView_ChallengeOverview.RowHeight = 195;
            tableView_ChallengeOverview.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /// <summary>
        /// Reload tabeView_Recipes from other Views
        /// </summary>
        /// <param name="firstViewController"></param>
        public static void Refresh(ChallengeOverviewViewController firstViewController)
        {
            firstViewController.ViewDidAppear(true);
        }
    }
}