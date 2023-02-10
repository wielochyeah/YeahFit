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
		UIKit.UITableView tableView_Workouts { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableView_Workouts != null) {
				tableView_Workouts.Dispose ();
				tableView_Workouts = null;
			}
		}
	}
}
