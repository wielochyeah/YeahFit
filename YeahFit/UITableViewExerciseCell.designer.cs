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
	[Register ("UITableViewExerciseCell")]
	partial class UITableViewExerciseCell
	{
		[Outlet]
		UIKit.UIImageView imageView_ExerciseGif { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ExerciseName { get; set; }

		[Outlet]
		UIKit.UILabel lbl_SetsTimes { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView_ExerciseGif != null) {
				imageView_ExerciseGif.Dispose ();
				imageView_ExerciseGif = null;
			}

			if (lbl_ExerciseName != null) {
				lbl_ExerciseName.Dispose ();
				lbl_ExerciseName = null;
			}

			if (lbl_SetsTimes != null) {
				lbl_SetsTimes.Dispose ();
				lbl_SetsTimes = null;
			}
		}
	}
}
