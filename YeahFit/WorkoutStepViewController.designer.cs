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
	[Register ("WorkoutStepViewController")]
	partial class WorkoutStepViewController
	{
		[Outlet]
		UIKit.UIButton btn_Break { get; set; }

		[Outlet]
		UIKit.UIButton btn_NextExercise { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_ExerciseGif { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ExerciseName { get; set; }

		[Outlet]
		UIKit.UILabel lbl_NextExercise { get; set; }

		[Outlet]
		UIKit.UILabel lbl_SetsReps { get; set; }

		[Outlet]
		UIKit.UILabel timerLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (timerLabel != null) {
				timerLabel.Dispose ();
				timerLabel = null;
			}

			if (lbl_ExerciseName != null) {
				lbl_ExerciseName.Dispose ();
				lbl_ExerciseName = null;
			}

			if (lbl_SetsReps != null) {
				lbl_SetsReps.Dispose ();
				lbl_SetsReps = null;
			}

			if (btn_NextExercise != null) {
				btn_NextExercise.Dispose ();
				btn_NextExercise = null;
			}

			if (imageView_ExerciseGif != null) {
				imageView_ExerciseGif.Dispose ();
				imageView_ExerciseGif = null;
			}

			if (lbl_NextExercise != null) {
				lbl_NextExercise.Dispose ();
				lbl_NextExercise = null;
			}

			if (btn_Break != null) {
				btn_Break.Dispose ();
				btn_Break = null;
			}
		}
	}
}
