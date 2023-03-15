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
	[Register ("AddExerciseViewController")]
	partial class AddExerciseViewController
	{
		[Outlet]
		UIKit.UIButton btn_AddExercise { get; set; }

		[Outlet]
		UIKit.UILabel lbl_Reps { get; set; }

		[Outlet]
		UIKit.UILabel lbl_Sets { get; set; }

		[Outlet]
		UIKit.UIStepper Stepper_Reps { get; set; }

		[Outlet]
		UIKit.UIStepper Stepper_Sets { get; set; }

		[Outlet]
		YeahFit.AddExerciseTableView tableView_AddExercise { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_Sets != null) {
				lbl_Sets.Dispose ();
				lbl_Sets = null;
			}

			if (lbl_Reps != null) {
				lbl_Reps.Dispose ();
				lbl_Reps = null;
			}

			if (Stepper_Sets != null) {
				Stepper_Sets.Dispose ();
				Stepper_Sets = null;
			}

			if (Stepper_Reps != null) {
				Stepper_Reps.Dispose ();
				Stepper_Reps = null;
			}

			if (tableView_AddExercise != null) {
				tableView_AddExercise.Dispose ();
				tableView_AddExercise = null;
			}

			if (btn_AddExercise != null) {
				btn_AddExercise.Dispose ();
				btn_AddExercise = null;
			}
		}
	}
}
