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
	[Register ("UITableViewAddWorkoutCell")]
	partial class UITableViewAddWorkoutCell
	{
		[Outlet]
		UIKit.UIImageView imageView_Exercise { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ExerciseName { get; set; }

		[Outlet]
		UIKit.UILabel lbl_SetsReps { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_ExerciseName != null) {
				lbl_ExerciseName.Dispose ();
				lbl_ExerciseName = null;
			}

			if (imageView_Exercise != null) {
				imageView_Exercise.Dispose ();
				imageView_Exercise = null;
			}

			if (lbl_SetsReps != null) {
				lbl_SetsReps.Dispose ();
				lbl_SetsReps = null;
			}
		}
	}
}
