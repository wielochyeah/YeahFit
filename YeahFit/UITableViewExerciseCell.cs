// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace YeahFit
{
	public partial class UITableViewExerciseCell : UITableViewCell
	{
		public UITableViewExerciseCell (IntPtr handle) : base (handle)
		{
		}

        /// <summary>
        /// Update each cell content
        /// </summary>
        /// <param name="selectedIngredient"></param>
        /// <param name="indexPath"></param>
        internal void UpdateCell(Exercise selectedExercise, int indexPath)
        {
            // Set ingredient text
            lbl_ExerciseName.Text = selectedExercise.IngredientName;
            lbl_SetsTimes.Text = selectedExercise.IngredientAmount;

            

            
        }
    }
}
