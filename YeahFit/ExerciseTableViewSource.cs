using System;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace YeahFit
{
	internal class ExerciseTableViewSource : UITableViewSource
    {
        private List<Exercise> exercises;
        UIViewController parentController;
        public static Exercise nowSelectedExercise;
        Workout selectedWorkout;
        public static Workout nowSelectedWorkout;

        public ExerciseTableViewSource(List<Exercise> exercises, UIViewController parentController, Workout selectedWorkout)
        {
            this.exercises = exercises;
            this.parentController = parentController;
            this.selectedWorkout = selectedWorkout;
        }

        /// <summary>
        /// Get the individual ingredient
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewExerciseCell)tableView.DequeueReusableCell("cell", indexPath);

            // Counter to allow addCell to be added at the end
            int iRow = indexPath.Row;
            if (indexPath.Row == exercises.Count && exercises.Count > 0)
            {
                iRow = indexPath.Row - 1;
            }

            var selectedExercise = exercises[iRow];

            // Update ingredient cell
            cell.UpdateCell(selectedExercise, iRow);
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
            return exercises.Count + 1;
        }

        
    }
}

