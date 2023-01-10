using System;
using System.Collections.Generic;
using DoAn.Model;
using DoAn.View;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;
using DoAn.Interfaces;
using DoAn.Services;
using Xamarin.CommunityToolkit.Extensions;
using DoAn.PopupPages;

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
            Init();
        }

        async void Init()
        {
            user = await userService.GetUser(auth.GetEmail());
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
                Application.Current.MainPage = new NavigationPage(new BeginningPage());
        }

        void ChangePassword_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword());
        }

        async void DeleteAccount_Clicked(System.Object sender, System.EventArgs e)
        {
            // display alert to confirm deleting action
            var result = await DisplayAlert("Delete Account", "Are you sure you want to delete your account?", "Yes", "No");
            if (!result)
                return;

            string email = auth.GetEmail();

            if (await auth.DeleteAccountAsync())
                Navigation.ShowPopup(new GoodByePopup());
            else
                Navigation.ShowPopup(new FailedActionPopup("Some thing went wrong! Please try again."));

     
        }

        void RefreshView_Refreshing(System.Object sender, System.EventArgs e)
        {
            Init();
            ProfileRefreshView.IsRefreshing = false;
        }
    }
}   

