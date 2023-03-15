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
	[Register ("UITableViewAddExerciseCell")]
	partial class UITableViewAddExerciseCell
	{
		[Outlet]
		UIKit.UIImageView imageView_Exercise { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ExerciseName { get; set; }

		[Outlet]
		UIKit.UIView view_background { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (view_background != null) {
				view_background.Dispose ();
				view_background = null;
			}

			if (lbl_ExerciseName != null) {
				lbl_ExerciseName.Dispose ();
				lbl_ExerciseName = null;
			}

			if (imageView_Exercise != null) {
				imageView_Exercise.Dispose ();
				imageView_Exercise = null;
			}
		}
	}
}
