using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using Foundation;
using UIKit;

namespace YeahFit
{
	public class AddWorkoutTableViewSource : UITableViewSource
	{
        private List<Exercise> exercises;
        UIViewController parentController;
        public static Exercise nowSelectedExercise;
        Workout selectedWorkout;
        public static Workout nowSelectedWorkout;

        public AddWorkoutTableViewSource(List<Exercise> exercises, UIViewController parentController, Workout selectedWorkout)
        {
            this.exercises = exercises;
            this.parentController = parentController;
            this.selectedWorkout = selectedWorkout;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewAddWorkoutCell)tableView.DequeueReusableCell("cell", indexPath);
            var addCell = (UITableViewAddWorkoutExerciseCell)tableView.DequeueReusableCell("addCell", indexPath);

            // Counter to allow addCell to be added at the end
            int iRow = indexPath.Row;
            if (indexPath.Row == exercises.Count && exercises.Count > 0)
            {
                iRow = indexPath.Row - 1;
            }

            var selectedStep = exercises[iRow];

            // Update step cell
            cell.UpdateCell(selectedStep, iRow);


            if (indexPath.Row == exercises.Count)
            {
                // Update cell for adding new steps
                addCell.UpdateCell(selectedStep, iRow, tableView);
                return addCell;
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return exercises.Count + 1;
        }

        /// <summary>
        /// If user selects a row
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            // Set internal recipe and step
            nowSelectedWorkout = selectedWorkout;
            nowSelectedExercise = exercises[indexPath.Row];

            // Show StepView and set index
            UIStoryboard board = UIStoryboard.FromName("Main", null);
            AddExerciseViewController ctrl = (AddExerciseViewController)board.InstantiateViewController("AddExerciseViewController");
            if (parentController != null)
            {
                AddExerciseViewController.index = indexPath.Row;
                parentController.ShowViewController(ctrl, this);
            }
        }

        /// <summary>
        /// Delete Steps (Swipe on cell)
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            // User can't delete AddStep or a step if there's only one step
            if (indexPath.Row < AddWorkoutViewController.exercises.Count && AddWorkoutViewController.exercises.Count > 1)
            {
                var action = UITableViewRowAction.Create
                (
                    UITableViewRowActionStyle.Default,
                    "Löschen", (arg1, arg2) =>
                    {
                        // Delete step from list
                        AddWorkoutViewController.exercises.RemoveAt(indexPath.Row);

                        // Reload tableView
                        tableView.ReloadData();
                    }
                );


                return new UITableViewRowAction[] { action };
            }
            else
            {
                var action = UITableViewRowAction.Create
                (
                    UITableViewRowActionStyle.Default,
                    "Kann nicht gelöscht werden", (arg1, arg2) =>
                    {
                    }
                );

                return new UITableViewRowAction[] { action };
            }
        }
    }
}

