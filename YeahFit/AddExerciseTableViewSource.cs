using System;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace YeahFit
{
	public class AddExerciseTableViewSource : UITableViewSource
	{
        public UINavigationController CurrentNavigationController;
        LastWorkoutsViewController owner;
        UIViewController parentController;

        public static InternalExercise nowSelectedExercise;
        public static InternalExercise selectedExercise;

        private List<InternalExercise> internalExercises;

        public AddExerciseTableViewSource(List<InternalExercise> internalExercises, UIViewController parentController, UINavigationController CurrentNavigationController)
        {
            this.internalExercises = internalExercises;
            this.parentController = parentController;
            this.CurrentNavigationController = CurrentNavigationController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewAddExerciseCell)tableView.DequeueReusableCell("cell", indexPath);

            selectedExercise = internalExercises[indexPath.Row];

            // Update ingredient cell
            cell.UpdateCell(selectedExercise, indexPath.Row);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return internalExercises.Count;
        }

        /// <summary>
        /// If user selects a row
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Get selected recipe
            nowSelectedExercise = internalExercises[indexPath.Row];

            // Set cells in the TableView
            var cell = (UITableViewAddExerciseCell)tableView.DequeueReusableCell("cell", indexPath);

            selectedExercise = internalExercises[indexPath.Row];

            // Update ingredient cell
            cell.ChangeColor(selectedExercise, indexPath.Row);

            UIStoryboard board = UIStoryboard.FromName("Main", null);

            // Show RecipeView and set index
            /*WorkoutViewController ctrl = (WorkoutViewController)board.InstantiateViewController("WorkoutViewController");
            if (parentController != null)
            {
                parentController.ShowViewController(ctrl, this);

                // Set index
                WorkoutViewController.index = indexPath.Row;
            }*/
        }
    }
}

