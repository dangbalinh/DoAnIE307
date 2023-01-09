using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DoAn.Model;
using DoAn.Services;
using Xamarin.Forms;

namespace DoAn.OriginalPage.Tips
{
    public partial class MoreTips : ContentPage
    {
        //ObservableCollection<Tip> tips;
        List<Tip> tips;
        DBFirebase services = new DBFirebase();

        public MoreTips()
        {
            InitializeComponent();
            Init();
        }

        async void Init()
        {
            tips = await services.GetAllTips();
            TipsListView.ItemsSource = tips;
        }

        void TipsListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var tip = e.SelectedItem as Tip;
            Navigation.PushAsync(new TipDetail(tip));
        }

        void TipSearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            TipsListView.ItemsSource = tips.Where(item => item.Title.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}

