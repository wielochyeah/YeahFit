// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace YeahFit
{
	[Register ("UITableViewWorkoutCell")]
	partial class UITableViewWorkoutCell
	{
		[Outlet]
		UIKit.UIButton btn_LikeWorkout { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_backgroundRectangleWhite { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_LikeWorkout { get; set; }

		[Outlet]
		YeahFit.UIImageViewWorkout imageView_Workout { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint lbl_category { get; set; }

		[Outlet]
		UIKit.UILabel lbl_difficulty { get; set; }

		[Outlet]
		UIKit.UILabel lbl_duration { get; set; }

		[Outlet]
		UIKit.UILabel lbl_WorkoutCategory { get; set; }

		[Outlet]
		UIKit.UILabel lbl_WorkoutName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_LikeWorkout != null) {
				btn_LikeWorkout.Dispose ();
				btn_LikeWorkout = null;
			}

			if (imageView_backgroundRectangleWhite != null) {
				imageView_backgroundRectangleWhite.Dispose ();
				imageView_backgroundRectangleWhite = null;
			}

			if (imageView_LikeWorkout != null) {
				imageView_LikeWorkout.Dispose ();
				imageView_LikeWorkout = null;
			}

			if (lbl_category != null) {
				lbl_category.Dispose ();
				lbl_category = null;
			}

			if (lbl_difficulty != null) {
				lbl_difficulty.Dispose ();
				lbl_difficulty = null;
			}

			if (lbl_duration != null) {
				lbl_duration.Dispose ();
				lbl_duration = null;
			}

			if (lbl_WorkoutCategory != null) {
				lbl_WorkoutCategory.Dispose ();
				lbl_WorkoutCategory = null;
			}

			if (imageView_Workout != null) {
				imageView_Workout.Dispose ();
				imageView_Workout = null;
			}

			if (lbl_WorkoutName != null) {
				lbl_WorkoutName.Dispose ();
				lbl_WorkoutName = null;
			}
		}
	}
}
