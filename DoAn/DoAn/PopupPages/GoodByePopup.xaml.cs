using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace DoAn.PopupPages
{
    public partial class GoodByePopup : Popup
    {
        public GoodByePopup()
        {
            InitializeComponent();
        }

        void Dismiss_Clicked(System.Object sender, System.EventArgs e)
        {
            Dismiss(null);
        }
    }
}

