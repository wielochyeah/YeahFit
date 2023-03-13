using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Foundation;
using UIKit;

namespace YeahFit
{
	public class LastWorkoutsTableViewSource : UITableViewSource
	{

        public UINavigationController CurrentNavigationController;
        LastWorkoutsViewController owner;
        UIViewController parentController;

        public static Workout nowSelectedWorkout;
        public static Workout selectedWorkout;

        private List<Workout> internalWorkouts;

        public LastWorkoutsTableViewSource(List<Workout> internalWorkouts, UIViewController parentController, UINavigationController CurrentNavigationController)
		{
			this.internalWorkouts = internalWorkouts;
            this.parentController = parentController;
            this.CurrentNavigationController = CurrentNavigationController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewLastWorkoutCell)tableView.DequeueReusableCell("cell", indexPath);

            selectedWorkout = internalWorkouts[indexPath.Row];

            // Update ingredient cell
            cell.UpdateCell(selectedWorkout, indexPath.Row);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return internalWorkouts.Count;
        }

        /// <summary>
        /// If user selects a row
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Get selected recipe
            nowSelectedWorkout = internalWorkouts[indexPath.Row];

            UIStoryboard board = UIStoryboard.FromName("Main", null);

            // Show RecipeView and set index
            WorkoutViewController ctrl = (WorkoutViewController)board.InstantiateViewController("WorkoutViewController");
            if (parentController != null)
            {
                parentController.ShowViewController(ctrl, this);

                // Set index
                WorkoutViewController.index = indexPath.Row;
            }
        }
    }
}

