// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace YeahFit
{
    public partial class WeekSettingsViewController : UIViewController
    {
        public static FirstViewController firstViewController;

        bool internalMonday = false;
        bool internalTuesday = false;
        bool internalWednesday = false;
        bool internalThursday = false;
        bool internalFriday = false;
        bool internalSaturday = false;
        bool internalSunday = false;

        public WeekSettingsViewController(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            internalMonday = InitializeWeek.monday;
            internalTuesday = InitializeWeek.tuesday;
            internalWednesday = InitializeWeek.wednesday;
            internalThursday = InitializeWeek.thursday;
            internalFriday = InitializeWeek.friday;
            internalSaturday = InitializeWeek.saturday;
            internalSunday = InitializeWeek.sunday;

            btn_Monday.TouchUpInside += (sender, e) =>
            {
                if (internalMonday == true)
                {
                    SelectButtonColor.SelectButton(btn_Monday, false);
                    internalMonday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Monday, true);
                    internalMonday = true;
                }
            };
            btn_Tuesday.TouchUpInside += (sender, e) =>
            {
                if (internalTuesday == true)
                {
                    SelectButtonColor.SelectButton(btn_Tuesday, false);
                    internalTuesday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Tuesday, true);
                    internalTuesday = true;
                }
            };
            btn_Wednesday.TouchUpInside += (sender, e) =>
            {
                if (internalWednesday == true)
                {
                    SelectButtonColor.SelectButton(btn_Wednesday, false);
                    internalWednesday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Wednesday, true);
                    internalWednesday = true;
                }
            };
            btn_Thursday.TouchUpInside += (sender, e) =>
            {
                if (internalThursday == true)
                {
                    SelectButtonColor.SelectButton(btn_Thursday, false);
                    internalThursday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Thursday, true);
                    internalThursday = true;
                }
            };
            btn_Friday.TouchUpInside += (sender, e) =>
            {
                if (internalFriday == true)
                {
                    SelectButtonColor.SelectButton(btn_Friday, false);
                    internalFriday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Friday, true);
                    internalFriday = true;
                }
            };
            btn_Saturday.TouchUpInside += (sender, e) =>
            {
                if (internalSaturday == true)
                {
                    SelectButtonColor.SelectButton(btn_Saturday, false);
                    internalSaturday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Saturday, true);
                    internalSaturday = true;
                }
            };
            btn_Sunday.TouchUpInside += (sender, e) =>
            {
                if (internalSunday == true)
                {
                    SelectButtonColor.SelectButton(btn_Sunday, false);
                    internalSunday = false;
                }
                else
                {
                    SelectButtonColor.SelectButton(btn_Sunday, true);
                    internalSunday = true;
                }
            };
            btn_SaveWeek.TouchUpInside += (sender, e) =>
            {
                if (LoginViewController.loggedin == true)
                {

                    this.DismissViewController(true, () => { FirstViewController.Refresh(firstViewController); });
                }
                Alert();
            };
        }

        void Alert()
        {
            if (LoginViewController.loggedin == false)
            {
                //Create Alert
                var okAlertController = UIAlertController.Create("Melde dich an", "Melde dich an, um deine Woche einstellen zu können.", UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                PresentViewController(okAlertController, true, null);
            }
        }

        /// <summary>
        /// View reappears
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Alert();
        }

        /// <summary>
        /// Reload FirstView if user swipes down the View
        /// + Set edit in SecondView false
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);


        }
    }
}
