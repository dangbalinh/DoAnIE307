using System;
using System.Collections.Generic;
using DoAn.Model;
using DoAn.View;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;

namespace DoAn.OriginalPage.User
{

    public partial class Profile : ContentPage
    {
        Model.User user = new Model.User
        {
            id = 1,
            name = "Buck",
            email = "cuhoangng@gmail.com",
            phone = "0123456789",
            address = "Ho Chi Minh City",
            password = null,
            img = "user.png"
        };

        public Profile()
        {
            InitializeComponent();
            BindingContext = user;

        }

        void EditProfile_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage(user));
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            // firebase logout
            // clear all navigation stack
            Navigation.PopToRootAsync();

            // go to login page
            Navigation.PushAsync(new LoginPage());
        }
    }
}   

