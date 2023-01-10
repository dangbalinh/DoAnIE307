using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace DoAn.PopupPages
{	
	public partial class MissingFieldPopup : Popup
	{	
		public MissingFieldPopup (string title)
		{
			InitializeComponent ();
            TitleLabel.Text = title;
        }

        void Dismiss_Clicked(System.Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}

