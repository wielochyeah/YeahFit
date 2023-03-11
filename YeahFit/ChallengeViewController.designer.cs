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
	[Register ("ChallengeViewController")]
	partial class ChallengeViewController
	{
		[Outlet]
		UIKit.UIButton btn_Apply { get; set; }

		[Outlet]
		UIKit.UIButton btn_LikeChallenge { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_LikeChallenge { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ChallengeName { get; set; }

		[Outlet]
		UIKit.UITableView tableView_Challenges { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView_LikeChallenge != null) {
				imageView_LikeChallenge.Dispose ();
				imageView_LikeChallenge = null;
			}

			if (btn_LikeChallenge != null) {
				btn_LikeChallenge.Dispose ();
				btn_LikeChallenge = null;
			}

			if (btn_Apply != null) {
				btn_Apply.Dispose ();
				btn_Apply = null;
			}

			if (lbl_ChallengeName != null) {
				lbl_ChallengeName.Dispose ();
				lbl_ChallengeName = null;
			}

			if (tableView_Challenges != null) {
				tableView_Challenges.Dispose ();
				tableView_Challenges = null;
			}
		}
	}
}
