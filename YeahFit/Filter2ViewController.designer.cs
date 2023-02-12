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
	[Register ("Filter2ViewController")]
	partial class Filter2ViewController
	{
		[Outlet]
		UIKit.UIButton btn_FilterAlphAsc { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterAlphDesc { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterConfirm { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterDifficultyAdvanced { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterDifficultyEasy { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterDifficultyHard { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterDurationAsc { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterDurationDesc { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterFirstAdded { get; set; }

		[Outlet]
		UIKit.UIButton btn_FilterLastAdded { get; set; }

		[Outlet]
		UIKit.UISearchBar searchBar_Filter { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (searchBar_Filter != null) {
				searchBar_Filter.Dispose ();
				searchBar_Filter = null;
			}

			if (btn_FilterLastAdded != null) {
				btn_FilterLastAdded.Dispose ();
				btn_FilterLastAdded = null;
			}

			if (btn_FilterFirstAdded != null) {
				btn_FilterFirstAdded.Dispose ();
				btn_FilterFirstAdded = null;
			}

			if (btn_FilterAlphAsc != null) {
				btn_FilterAlphAsc.Dispose ();
				btn_FilterAlphAsc = null;
			}

			if (btn_FilterAlphDesc != null) {
				btn_FilterAlphDesc.Dispose ();
				btn_FilterAlphDesc = null;
			}

			if (btn_FilterDurationAsc != null) {
				btn_FilterDurationAsc.Dispose ();
				btn_FilterDurationAsc = null;
			}

			if (btn_FilterDurationDesc != null) {
				btn_FilterDurationDesc.Dispose ();
				btn_FilterDurationDesc = null;
			}

			if (btn_FilterDifficultyEasy != null) {
				btn_FilterDifficultyEasy.Dispose ();
				btn_FilterDifficultyEasy = null;
			}

			if (btn_FilterDifficultyAdvanced != null) {
				btn_FilterDifficultyAdvanced.Dispose ();
				btn_FilterDifficultyAdvanced = null;
			}

			if (btn_FilterDifficultyHard != null) {
				btn_FilterDifficultyHard.Dispose ();
				btn_FilterDifficultyHard = null;
			}

			if (btn_FilterConfirm != null) {
				btn_FilterConfirm.Dispose ();
				btn_FilterConfirm = null;
			}
		}
	}
}
