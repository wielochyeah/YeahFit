// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace YeahFit
{
    public partial class UITableViewLastWorkoutCell : UITableViewCell
    {
        public UITableViewLastWorkoutCell(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Update each cell content
        /// </summary>
        /// <param name="selectedIngredient"></param>
        /// <param name="indexPath"></param>
        internal void UpdateCell(Workout selectedWorkout, int indexPath)
        {
            // Set ingredient text
            lbl_WorkoutName.Text = selectedWorkout.WorkoutName;
            lbl_WorkoutDate.Text = selectedWorkout.WorkoutName + "x";

            //
            // Recipe image
            //

            // Get recipe image from byte array
            var data = NSData.FromArray(selectedWorkout.WorkoutImage);

            // Convert to UIImage
            UIImage image = UIImage.LoadFromData(data);

            // Set as image
            imageView_Workout.Image = image;

            // AspectFill
            imageView_Workout.ContentMode = UIViewContentMode.ScaleAspectFill;
        }
    }
}
