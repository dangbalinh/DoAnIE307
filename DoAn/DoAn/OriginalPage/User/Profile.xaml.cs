using System;
using System.Collections.Generic;
using DoAn.Model;
using DoAn.View;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;
using DoAn.Interfaces;
using DoAn.Services;

namespace DoAn.OriginalPage.User
{
    public partial class Profile : ContentPage
    {
        readonly IAuth auth;
        readonly UserService userService = new UserService();
        Model.User user;

        public Profile()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            //Init();

            //user = new Model.User
            //{
            //    name = "Buck",
            //    email = auth.GetEmail(),
            //    phone = "0123456789",
            //    address = "Ho Chi Minh City",
            //    img = "user.png"
            //};

            //BindingContext = user;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            user = await userService.GetUser(auth.GetEmail());
            if (user.phone == "")
            {
                UserPhone.Text = "Undefined";
                UserPhone.TextColor = Color.Red;
            }
            if (user.address == "")
            {
                UserAddress.Text = "Undefined";
                UserAddress.TextColor = Color.Red;
            }

            BindingContext = user;

        }

        //public async void Init()
        //{
        //    user = await userService.GetUser(auth.GetEmail());

        //}

        void EditProfile_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new EditProfilePage(user));
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            var signOut = auth.SignOutAsync();

            if (signOut)
                Application.Current.MainPage = new MainPage();
        }

        void ChangePassword_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }

        async void RefreshView_Refreshing(System.Object sender, System.EventArgs e)
        {
            user = await userService.GetUser(auth.GetEmail());
            if (user.phone == "")
            {
                UserPhone.Text = "Undefined";
                UserPhone.TextColor = Color.Red;
            }
            if (user.address == "")
            {
                UserAddress.Text = "Undefined";
                UserAddress.TextColor = Color.Red;
            }

            BindingContext = user;

            ProfileRefreshView.IsRefreshing = false;
        }
    }
}   

