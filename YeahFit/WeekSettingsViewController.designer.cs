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
	[Register ("WeekSettingsViewController")]
	partial class WeekSettingsViewController
	{
		[Outlet]
		UIKit.UIButton btn_Friday { get; set; }

		[Outlet]
		UIKit.UIButton btn_Monday { get; set; }

		[Outlet]
		UIKit.UIButton btn_Saturday { get; set; }

		[Outlet]
		UIKit.UIButton btn_SaveWeek { get; set; }

		[Outlet]
		UIKit.UIButton btn_Sunday { get; set; }

		[Outlet]
		UIKit.UIButton btn_Thursday { get; set; }

		[Outlet]
		UIKit.UIButton btn_Tuesday { get; set; }

		[Outlet]
		UIKit.UIButton btn_Wednesday { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_Monday != null) {
				btn_Monday.Dispose ();
				btn_Monday = null;
			}

			if (btn_Tuesday != null) {
				btn_Tuesday.Dispose ();
				btn_Tuesday = null;
			}

			if (btn_Wednesday != null) {
				btn_Wednesday.Dispose ();
				btn_Wednesday = null;
			}

			if (btn_Thursday != null) {
				btn_Thursday.Dispose ();
				btn_Thursday = null;
			}

			if (btn_Friday != null) {
				btn_Friday.Dispose ();
				btn_Friday = null;
			}

			if (btn_Saturday != null) {
				btn_Saturday.Dispose ();
				btn_Saturday = null;
			}

			if (btn_Sunday != null) {
				btn_Sunday.Dispose ();
				btn_Sunday = null;
			}

			if (btn_SaveWeek != null) {
				btn_SaveWeek.Dispose ();
				btn_SaveWeek = null;
			}
		}
	}
}
