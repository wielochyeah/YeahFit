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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		UIKit.UIButton btn_Login { get; set; }

		[Outlet]
		UIKit.UILabel lbl_LoginComment { get; set; }

		[Outlet]
		UIKit.UITextField txtField_Password { get; set; }

		[Outlet]
		UIKit.UITextField txtField_Username { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbl_LoginComment != null) {
				lbl_LoginComment.Dispose ();
				lbl_LoginComment = null;
			}

			if (txtField_Username != null) {
				txtField_Username.Dispose ();
				txtField_Username = null;
			}

			if (txtField_Password != null) {
				txtField_Password.Dispose ();
				txtField_Password = null;
			}

			if (btn_Login != null) {
				btn_Login.Dispose ();
				btn_Login = null;
			}
		}
	}
}
