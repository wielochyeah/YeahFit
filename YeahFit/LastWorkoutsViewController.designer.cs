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
	[Register ("LastWorkoutsViewController")]
	partial class LastWorkoutsViewController
	{
		[Outlet]
		YeahFit.LastWorkoutTableView lastWorkoutsTableView { get; set; }

		[Outlet]
		YeahFit.LastWorkoutTableView LastWorkoutTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LastWorkoutTableView != null) {
				LastWorkoutTableView.Dispose ();
				LastWorkoutTableView = null;
			}

			if (lastWorkoutsTableView != null) {
				lastWorkoutsTableView.Dispose ();
				lastWorkoutsTableView = null;
			}
		}
	}
}
