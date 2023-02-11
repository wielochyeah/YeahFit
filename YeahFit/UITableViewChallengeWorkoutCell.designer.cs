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
	[Register ("UITableViewChallengeWorkoutCell")]
	partial class UITableViewChallengeWorkoutCell
	{
		[Outlet]
		YeahFit.UIImageViewChallenge imageView_Workout { get; set; }

		[Outlet]
		UIKit.UILabel lbl_categoryDifficulty { get; set; }

		[Outlet]
		UIKit.UILabel lbl_Weekday { get; set; }

		[Outlet]
		UIKit.UILabel lbl_WorkoutName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_Weekday != null) {
				lbl_Weekday.Dispose ();
				lbl_Weekday = null;
			}

			if (lbl_categoryDifficulty != null) {
				lbl_categoryDifficulty.Dispose ();
				lbl_categoryDifficulty = null;
			}

			if (lbl_WorkoutName != null) {
				lbl_WorkoutName.Dispose ();
				lbl_WorkoutName = null;
			}

			if (imageView_Workout != null) {
				imageView_Workout.Dispose ();
				imageView_Workout = null;
			}
		}
	}
}
