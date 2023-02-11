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
	[Register ("UITableViewChallengeCell")]
	partial class UITableViewChallengeCell
	{
		[Outlet]
		YeahFit.UIImageViewChallenge imageView_ChallengeOverview { get; set; }

		[Outlet]
		UIKit.UIImageView imageView_LikeChallenge { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ChallengeDaysPerWeek { get; set; }

		[Outlet]
		UIKit.UILabel lbl_ChallengeName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView_ChallengeOverview != null) {
				imageView_ChallengeOverview.Dispose ();
				imageView_ChallengeOverview = null;
			}

			if (lbl_ChallengeDaysPerWeek != null) {
				lbl_ChallengeDaysPerWeek.Dispose ();
				lbl_ChallengeDaysPerWeek = null;
			}

			if (lbl_ChallengeName != null) {
				lbl_ChallengeName.Dispose ();
				lbl_ChallengeName = null;
			}

			if (imageView_LikeChallenge != null) {
				imageView_LikeChallenge.Dispose ();
				imageView_LikeChallenge = null;
			}
		}
	}
}
