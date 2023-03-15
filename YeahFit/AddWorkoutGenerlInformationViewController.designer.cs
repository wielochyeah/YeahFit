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
	[Register ("AddWorkoutGenerlInformationViewController")]
	partial class AddWorkoutGenerlInformationViewController
	{
		[Outlet]
		UIKit.UIButton btn_ConfirmWorkoutGeneralInformation { get; set; }

		[Outlet]
		UIKit.UIDatePicker datePicker_WorkoutDuration { get; set; }

		[Outlet]
		UIKit.UISegmentedControl segmentedControl_WorkoutDifficulty { get; set; }

		[Outlet]
		UIKit.UISwitch switch_Core { get; set; }

		[Outlet]
		UIKit.UISwitch switch_FullBody { get; set; }

		[Outlet]
		UIKit.UISwitch switch_LowerBody { get; set; }

		[Outlet]
		UIKit.UISwitch switch_NoEquipment { get; set; }

		[Outlet]
		UIKit.UISwitch switch_Pull { get; set; }

		[Outlet]
		UIKit.UISwitch switch_Push { get; set; }

		[Outlet]
		UIKit.UISwitch switch_UpperBody { get; set; }

		[Outlet]
		UIKit.UITextField txtField_WorkoutName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtField_WorkoutName != null) {
				txtField_WorkoutName.Dispose ();
				txtField_WorkoutName = null;
			}

			if (segmentedControl_WorkoutDifficulty != null) {
				segmentedControl_WorkoutDifficulty.Dispose ();
				segmentedControl_WorkoutDifficulty = null;
			}

			if (switch_FullBody != null) {
				switch_FullBody.Dispose ();
				switch_FullBody = null;
			}

			if (datePicker_WorkoutDuration != null) {
				datePicker_WorkoutDuration.Dispose ();
				datePicker_WorkoutDuration = null;
			}

			if (switch_UpperBody != null) {
				switch_UpperBody.Dispose ();
				switch_UpperBody = null;
			}

			if (switch_LowerBody != null) {
				switch_LowerBody.Dispose ();
				switch_LowerBody = null;
			}

			if (switch_Push != null) {
				switch_Push.Dispose ();
				switch_Push = null;
			}

			if (switch_Pull != null) {
				switch_Pull.Dispose ();
				switch_Pull = null;
			}

			if (switch_Core != null) {
				switch_Core.Dispose ();
				switch_Core = null;
			}

			if (switch_NoEquipment != null) {
				switch_NoEquipment.Dispose ();
				switch_NoEquipment = null;
			}

			if (btn_ConfirmWorkoutGeneralInformation != null) {
				btn_ConfirmWorkoutGeneralInformation.Dispose ();
				btn_ConfirmWorkoutGeneralInformation = null;
			}
		}
	}
}
