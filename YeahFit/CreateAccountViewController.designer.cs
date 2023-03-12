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
	[Register ("CreateAccountViewController")]
	partial class CreateAccountViewController
	{
		[Outlet]
		UIKit.UIButton txtField_CreateUser { get; set; }

		[Outlet]
		UIKit.UITextField txtField_Password { get; set; }

		[Outlet]
		UIKit.UITextField txtField_PasswordRepeat { get; set; }

		[Outlet]
		UIKit.UITextField txtField_Username { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtField_Username != null) {
				txtField_Username.Dispose ();
				txtField_Username = null;
			}

			if (txtField_Password != null) {
				txtField_Password.Dispose ();
				txtField_Password = null;
			}

			if (txtField_PasswordRepeat != null) {
				txtField_PasswordRepeat.Dispose ();
				txtField_PasswordRepeat = null;
			}

			if (txtField_CreateUser != null) {
				txtField_CreateUser.Dispose ();
				txtField_CreateUser = null;
			}
		}
	}
}
