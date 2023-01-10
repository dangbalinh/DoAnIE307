using DoAn.OriginalPage.Taskpage;
using System;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoAn.OriginalPage.Booking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Property property)
        {
            InitializeComponent();
            this.Property = property;
            this.BindingContext = this;
        }
        public Property Property { get; set; }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }



        private void CallTap_Tapped(object sender, EventArgs e)
        {
            PhoneDialer.Open("0906592672");
        }

        private async void EmailTap_Tapped(object sender, EventArgs e)
        {
            await Email.ComposeAsync("", "", Property.email);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 400;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        private async void MapTap_Tapped(object sender, EventArgs e)
        {
            await Map.OpenAsync(Property.latitude, Property.longitude);
        }

        private void AddTodoList_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EntryTaskPage());
        }
    }
}