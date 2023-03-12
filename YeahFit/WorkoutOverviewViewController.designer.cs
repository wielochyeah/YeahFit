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
	[Register ("WorkoutOverviewViewController")]
	partial class WorkoutOverviewViewController
	{
		[Outlet]
		UIKit.UIButton btn_Core { get; set; }

		[Outlet]
		UIKit.UIButton btn_FullBody { get; set; }

		[Outlet]
		UIKit.UIButton btn_Like { get; set; }

		[Outlet]
		UIKit.UIButton btn_LikeWorkout { get; set; }

		[Outlet]
		UIKit.UIButton btn_LowerBody { get; set; }

		[Outlet]
		UIKit.UIButton btn_NoEquipment { get; set; }

		[Outlet]
		UIKit.UIButton btn_Pull { get; set; }

		[Outlet]
		UIKit.UIButton btn_Push { get; set; }

		[Outlet]
		UIKit.UIButton btn_TwentyMinutes { get; set; }

		[Outlet]
		UIKit.UIButton btn_UpperBody { get; set; }

		[Outlet]
		UIKit.UITableView tableView_Workouts { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_Like != null) {
				btn_Like.Dispose ();
				btn_Like = null;
			}

			if (btn_LikeWorkout != null) {
				btn_LikeWorkout.Dispose ();
				btn_LikeWorkout = null;
			}

			if (tableView_Workouts != null) {
				tableView_Workouts.Dispose ();
				tableView_Workouts = null;
			}

			if (btn_FullBody != null) {
				btn_FullBody.Dispose ();
				btn_FullBody = null;
			}

			if (btn_UpperBody != null) {
				btn_UpperBody.Dispose ();
				btn_UpperBody = null;
			}

			if (btn_LowerBody != null) {
				btn_LowerBody.Dispose ();
				btn_LowerBody = null;
			}

			if (btn_Push != null) {
				btn_Push.Dispose ();
				btn_Push = null;
			}

			if (btn_Pull != null) {
				btn_Pull.Dispose ();
				btn_Pull = null;
			}

			if (btn_Core != null) {
				btn_Core.Dispose ();
				btn_Core = null;
			}

			if (btn_TwentyMinutes != null) {
				btn_TwentyMinutes.Dispose ();
				btn_TwentyMinutes = null;
			}

			if (btn_NoEquipment != null) {
				btn_NoEquipment.Dispose ();
				btn_NoEquipment = null;
			}
		}
	}
}
