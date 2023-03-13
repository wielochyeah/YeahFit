using System;
using UIKit;

namespace YeahFit
{
	public class SelectButtonColor
	{
        public static void SelectButton(UIButton button, bool selected)
        {
            if (selected)
            {
                button.TintColor = UIColor.FromRGB(70, 133, 147);
            }
            else
            {
                button.TintColor = UIColor.LightGray;
            }
        }
    }
}

