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
	[Register ("UITableViewLastWorkoutCell")]
	partial class UITableViewLastWorkoutCell
	{
		[Outlet]
		UIKit.UIImageView imageView_Workout { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_WorkoutGif { get; set; }

		[Outlet]
		UIKit.UILabel lbl_WorkoutDate { get; set; }

		[Outlet]
		UIKit.UILabel lbl_WorkoutName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView_WorkoutGif != null) {
				imageView_WorkoutGif.Dispose ();
				imageView_WorkoutGif = null;
			}

			if (imageView_Workout != null) {
				imageView_Workout.Dispose ();
				imageView_Workout = null;
			}

			if (lbl_WorkoutName != null) {
				lbl_WorkoutName.Dispose ();
				lbl_WorkoutName = null;
			}

			if (lbl_WorkoutDate != null) {
				lbl_WorkoutDate.Dispose ();
				lbl_WorkoutDate = null;
			}
		}
	}
}
