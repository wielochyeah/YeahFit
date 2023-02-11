using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace YeahFit
{
	internal class WorkoutTableViewSource : UITableViewSource
    {
        public UINavigationController CurrentNavigationController;
        WorkoutOverviewViewController owner;
        UIViewController parentController;

        List<Workout> workouts;
        public static Workout nowSelectedWorkout;
        public static Workout selectedWorkout;

        public WorkoutTableViewSource(List<Workout> workouts, UIViewController parentController, UINavigationController CurrentNavigationController)
        {
            this.workouts = workouts;
            this.parentController = parentController;
            this.CurrentNavigationController = CurrentNavigationController;
        }

        /// <summary>
        /// Get the individual recipe
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewWorkoutCell)tableView.DequeueReusableCell("cell", indexPath);

            selectedWorkout = workouts[indexPath.Row];

            // Update recipe cell
            cell.UpdateCell(selectedWorkout, indexPath.Row);

            return cell;
        }

        /// <summary>
        /// Count rows
        /// </summary>
        /// <param name="tableview"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return workouts.Count;
        }

        /// <summary>
        /// If user selects a row
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Get selected recipe
            nowSelectedWorkout = workouts[indexPath.Row];

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

