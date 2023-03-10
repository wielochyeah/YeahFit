using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using UIKit;

namespace YeahFit
{
    public partial class FirstViewController : UIViewController
    {
        public static bool monday = true;
        public static bool tuesday = true;
        public static bool wednesday = true;
        public static bool thursday = true;
        public static bool friday = true;
        public static bool saturday = true;
        public static bool sunday = true;

        public FirstViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            int date = Convert.ToInt32(DateTime.Now.ToString("dd"));
            DateTime dateValue = DateTime.Today;
            string weekDay = dateValue.ToString("ddd").ToUpper();
            LoginViewController.firstViewController = this;
            WeekSettingsViewController.firstViewController = this;

            if (monday == false)
            {
                lbl_Monday.TextColor = UIColor.SystemGray;
                lbl_MondayDate.TextColor = UIColor.SystemGray;
                imageView_MondayCircle.TintColor = UIColor.SystemGray;
            }
            if (tuesday == false)
            {
                lbl_Tuesday.TextColor = UIColor.SystemGray;
                lbl_TuesdayDate.TextColor = UIColor.SystemGray;
                imageView_TuesdayCircle.TintColor = UIColor.SystemGray;
            }
            if (wednesday == false)
            {
                lbl_Wednesday.TextColor = UIColor.SystemGray;
                lbl_WednesdayDate.TextColor = UIColor.SystemGray;
                imageView_WednesdayCircle.TintColor = UIColor.SystemGray;
            }
            if (thursday == false)
            {
                lbl_thursday.TextColor = UIColor.SystemGray;
                lbl_ThursdayCircle.TintColor = UIColor.SystemGray;
                lbl_ThursdayDate.TextColor = UIColor.SystemGray;
            }
            if (friday == false)
            {
                lbl_Friday.TextColor = UIColor.SystemGray;
                lbl_FridayDate.TextColor = UIColor.SystemGray;
                imageView_FridayCircle.TintColor = UIColor.SystemGray;
            }
            if (saturday == false)
            {
                lbl_Saturday.TextColor = UIColor.SystemGray;
                lbl_SaturdayCircle.TintColor = UIColor.SystemGray;
                lbl_SaturdayDate.TextColor = UIColor.SystemGray;
            }
            if (sunday == false)
            {
                lbl_Sunday.TextColor = UIColor.SystemGray;
                lbl_SundayCircle.TintColor = UIColor.SystemGray;
                lbl_SundayDate.TextColor = UIColor.SystemGray;
            }

            switch (weekDay)
            {
                case "MO":
                    lbl_MondayDate.Text = (date + 0).ToString("D2");
                    lbl_TuesdayDate.Text = (date + 1).ToString("D2");
                    lbl_WednesdayDate.Text = (date + 2).ToString("D2");
                    lbl_ThursdayDate.Text = (date + 3).ToString("D2");
                    lbl_FridayDate.Text = (date + 4).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 5).ToString("D2");
                    lbl_SundayDate.Text = (date + 6).ToString("D2");
                    break;
                case "DI":
                    lbl_MondayDate.Text = (date - 1).ToString("D2");
                    lbl_TuesdayDate.Text = (date + 0).ToString("D2");
                    lbl_WednesdayDate.Text = (date + 1).ToString("D2");
                    lbl_ThursdayDate.Text = (date + 2).ToString("D2");
                    lbl_FridayDate.Text = (date + 3).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 4).ToString("D2");
                    lbl_SundayDate.Text = (date + 5).ToString("D2");
                    break;
                case "MI":
                    lbl_MondayDate.Text = (date - 2).ToString("D2");
                    lbl_TuesdayDate.Text = (date - 1).ToString("D2");
                    lbl_WednesdayDate.Text = (date + 0).ToString("D2");
                    lbl_ThursdayDate.Text = (date + 1).ToString("D2");
                    lbl_FridayDate.Text = (date + 2).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 3).ToString("D2");
                    lbl_SundayDate.Text = (date + 4).ToString("D2");
                    break;
                case "DO":
                    lbl_MondayDate.Text = (date - 3).ToString("D2");
                    lbl_TuesdayDate.Text = (date - 2).ToString("D2");
                    lbl_WednesdayDate.Text = (date - 1).ToString("D2");
                    lbl_ThursdayDate.Text = (date + 0).ToString("D2");
                    lbl_FridayDate.Text = (date + 1).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 2).ToString("D2");
                    lbl_SundayDate.Text = (date + 3).ToString("D2");
                    break;
                case "FR":
                    lbl_MondayDate.Text = (date - 4).ToString("D2");
                    lbl_TuesdayDate.Text = (date - 3).ToString("D2");
                    lbl_WednesdayDate.Text = (date - 2).ToString("D2");
                    lbl_ThursdayDate.Text = (date - 1).ToString("D2");
                    lbl_FridayDate.Text = (date + 0).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 1).ToString("D2");
                    lbl_SundayDate.Text = (date + 2).ToString("D2");
                    break;
                case "SA":
                    lbl_MondayDate.Text = (date - 5).ToString("D2");
                    lbl_TuesdayDate.Text = (date - 4).ToString("D2");
                    lbl_WednesdayDate.Text = (date - 3).ToString("D2");
                    lbl_ThursdayDate.Text = (date - 2).ToString("D2");
                    lbl_FridayDate.Text = (date - 1).ToString("D2");
                    lbl_SaturdayDate.Text = (date + 0).ToString("D2");
                    lbl_SundayDate.Text = (date + 1).ToString("D2");
                    break;
                case "SO":
                    lbl_MondayDate.Text = (date - 6).ToString("D2");
                    lbl_TuesdayDate.Text = (date - 5).ToString("D2");
                    lbl_WednesdayDate.Text = (date - 4).ToString("D2");
                    lbl_ThursdayDate.Text = (date - 3).ToString("D2");
                    lbl_FridayDate.Text = (date - 2).ToString("D2");
                    lbl_SaturdayDate.Text = (date - 1).ToString("D2");
                    lbl_SundayDate.Text = (date + 0).ToString("D2");
                    break;
                default:
                    break;
            }

            
        }

        /// <summary>
        /// Reload tabeView_Recipes from other Views
        /// </summary>
        /// <param name="firstViewController"></param>
        public static void Refresh(FirstViewController firstViewController)
        {
            firstViewController.ViewDidAppear(true);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
