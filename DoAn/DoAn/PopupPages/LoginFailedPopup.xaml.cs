using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace DoAn.PopupPages
{	
	public partial class LoginFailedPopup : Popup
	{	
		public LoginFailedPopup ()
		{
			InitializeComponent ();
		}

        void Dismiss_Clicked(System.Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}

