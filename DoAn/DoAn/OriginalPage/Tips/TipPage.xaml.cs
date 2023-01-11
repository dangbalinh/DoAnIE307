using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoAn.Model;
using Xamarin.Forms;
using DoAn.Services;
using Firebase.Database;

namespace DoAn.OriginalPage.Tips
{
    public partial class TipPage : ContentPage
    {
        List<Tip> tips;
        DBFirebase services = new DBFirebase();

        public TipPage()
        {
            InitializeComponent();
            Init();
            BindingContext = tips;

        }

        async void Init()
        {
            tips = await services.GetTheFirst4Tips();
            TipsCarouselView.ItemsSource = tips;
        }

        void MoreTips_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MoreTips());
        }

        void TipsCarouselView_CurrentItemChanged(System.Object sender, Xamarin.Forms.CurrentItemChangedEventArgs e)
        {
            var cur = e.CurrentItem as Tip;
            TipContent.Text = cur.Content;
        }
    }
}

