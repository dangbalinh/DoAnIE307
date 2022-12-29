using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoAn.Model;
using Xamarin.Forms;

namespace DoAn.OriginalPage.Tips
{
    public partial class TipPage : ContentPage
    {
        ObservableCollection<Tip> tips;

        public TipPage()
        {
            InitializeComponent();
            tips = new ObservableCollection<Tip>
            {
                new Tip{Title="Hot new", Image="teamwork1.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork2.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork3.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork4.png", Tag="Life", Content="Lorem ipsum"},
                new Tip{Title="Hot new", Image="teamwork5.png", Tag="Life", Content="Lorem ipsum"},
            };

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

