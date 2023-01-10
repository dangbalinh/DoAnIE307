using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace DoAn.PopupPages
{
    public partial class SuccessPopup : Popup
    {
        public SuccessPopup(string title)
        {
            InitializeComponent();
            TextLabel.Text = title;
        }

        void Dismiss_Clicked(System.Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}

