using System;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace YeahFit
{
	internal class ExerciseTableViewSource : UITableViewSource
    {
        private List<Exercise> internalExercises;

        public ExerciseTableViewSource(List<Exercise> internalExercises)
        {
            this.internalExercises = internalExercises;
        }

        /// <summary>
        /// Get the individual step
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewExerciseCell)tableView.DequeueReusableCell("cell", indexPath);

            var selectedExercise = internalExercises[indexPath.Row];

            // Update ingredient cell
            cell.UpdateCell(selectedExercise, indexPath.Row);

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
            return internalExercises.Count;
        }


    }
}

