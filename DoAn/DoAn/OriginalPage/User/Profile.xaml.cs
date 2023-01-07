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
    public class DisplayedInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        public DisplayedInfo(Model.User user)
        {
            Name = user.name;
            Email = user.email;
            Phone = user.phone;
            Address = user.address;
            Image = user.img;
        }
    }

    public partial class Profile : ContentPage
    {
        readonly IAuth auth;
        readonly UserService userService = new UserService();
        DisplayedInfo displayedInfo;
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
            //if (user.phone == "")
            //{
            //    UserPhone.Text = "Undefined";
            //    UserPhone.TextColor = Color.Red;
            //}
            //if (user.address == "")
            //{
            //    UserAddress.Text = "Undefined";
            //    UserAddress.TextColor = Color.Red;
            //}

            displayedInfo = new DisplayedInfo(user);
            dataForm.DataObject = displayedInfo;
            BindingContext = user;

        }

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
            //if (user.phone == "")
            //{
            //    UserPhone.Text = "Undefined";
            //    UserPhone.TextColor = Color.Red;
            //}
            //if (user.address == "")
            //{
            //    UserAddress.Text = "Undefined";
            //    UserAddress.TextColor = Color.Red;
            //}

            BindingContext = user;

            ProfileRefreshView.IsRefreshing = false;
        }
    }
}   

