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
            PhoneDialer.Open("234832894");
        }

        private async void EmailTap_Tapped(object sender, EventArgs e)
        {
            await Email.ComposeAsync("", "", "hungthinhTour@gmail.com");
        }


    }
}