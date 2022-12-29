using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DoAn.Model;
using Xamarin.Forms;

namespace DoAn.OriginalPage.Tips
{
    public partial class MoreTips : ContentPage
    {
        ObservableCollection<Tip> tips;
        public MoreTips()
        {
            InitializeComponent();
            tips = new ObservableCollection<Tip>
            {
                new Tip{Title="Hot new", Image="teamwork1.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork2.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork3.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork4.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork5.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Team work", Image="teamwork5.png", Tag="Life", Content="Lorem ipsum"},
            };

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

