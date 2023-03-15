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
		UIKit.UIButton btn_takePhoto { get; set; }

		[Outlet]
		UIKit.UITextField lbl_workoutName { get; set; }

		[Outlet]
		Foundation.NSObject tableView_AddWorkout { get; set; }

		[Outlet]
		YeahFit.AddWorkoutTableView tableView_AddWorkouts { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_AddWorkout != null) {
				btn_AddWorkout.Dispose ();
				btn_AddWorkout = null;
			}

			if (lbl_workoutName != null) {
				lbl_workoutName.Dispose ();
				lbl_workoutName = null;
			}

			if (tableView_AddWorkout != null) {
				tableView_AddWorkout.Dispose ();
				tableView_AddWorkout = null;
			}

			if (tableView_AddWorkouts != null) {
				tableView_AddWorkouts.Dispose ();
				tableView_AddWorkouts = null;
			}

			if (btn_takePhoto != null) {
				btn_takePhoto.Dispose ();
				btn_takePhoto = null;
			}
		}
	}
}
