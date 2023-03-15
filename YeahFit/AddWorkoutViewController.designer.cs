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
	[Register ("AddWorkoutViewController")]
	partial class AddWorkoutViewController
	{
		[Outlet]
		UIKit.UIButton btn_AddWorkout { get; set; }

		[Outlet]
		UIKit.UITextField lbl_workoutName { get; set; }

		[Outlet]
		Foundation.NSObject tableView_AddWorkout { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_workoutName != null) {
				lbl_workoutName.Dispose ();
				lbl_workoutName = null;
			}

			if (tableView_AddWorkout != null) {
				tableView_AddWorkout.Dispose ();
				tableView_AddWorkout = null;
			}

			if (btn_AddWorkout != null) {
				btn_AddWorkout.Dispose ();
				btn_AddWorkout = null;
			}
		}
	}
}
