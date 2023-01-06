using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Interfaces;
namespace DoAn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        //UserRepository _userRepository = new UserRepository();
        IAuth auth;
        public ChangePassword()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        //private async void BtnChangePassword_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string password = TxtPassword.Text;
        //        string confirmPass = TxtConfirm.Text;
        //        if (string.IsNullOrEmpty(password))
        //        {
        //            await DisplayAlert("Change Password", "Please type password", "Ok");
        //            return;
        //        }
        //        if (string.IsNullOrEmpty(confirmPass))
        //        {
        //            await DisplayAlert("Change Password", "Please type confirm password", "Ok");
        //            return;
        //        }
        //        if (password != confirmPass)
        //        {
        //            await DisplayAlert("Change Password", "Confirm password not match.", "Ok");
        //            return;
        //        }
        //        string token = Preferences.Get("token", "");
        //        string newToken = await _userRepository.ChangePassword(token, password);
        //        if (!string.IsNullOrEmpty(newToken))
        //        {
        //            await DisplayAlert("Change Password", "Password has been changed.", "Ok");
        //            Preferences.Set("token", newToken);
        //            //Preferences.Clear();
        //            //await Navigation.PushAsync(new LoginPage());
        //        }
        //        else
        //        {
        //            await DisplayAlert("Change Password", "Password Change failed.", "Ok");
        //        }
        //    }
        //    catch (Exception exception)
        //    {

        //    }

        //}

        private async void BtnChangePassword_Clicked(object sender, EventArgs e)
        {
            // check if the current password is correct
            if(!(await auth.CheckPasswordAsync(txtCurPassword.Text)))
            {
                await DisplayAlert("Change Password", "Current password is incorrect", "Ok");
                return;
            }

            // check if the new password is valid
            if (TxtPassword.Text != TxtConfirm.Text)
            {
                await DisplayAlert("Change Password", "Confirm password not match.", "Ok");
                return;
            } else if (TxtPassword.Text.Length < 6)
            {
                await DisplayAlert("Change Password", "Password must be at least 6 characters", "Ok");
                return;
            } else if (TxtPassword.Text == "")
            {
                await DisplayAlert("Change Password", "Password cannot be empty", "Ok");
                return;
            } else if (TxtPassword.Text == txtCurPassword.Text)
            {
                await DisplayAlert("Change Password", "New password must be different from current password", "Ok");
                return;
            }

            // change password
            if (await auth.ChangePasswordAsync(auth.GetEmail(), txtCurPassword.Text , TxtPassword.Text))
            {
                await DisplayAlert("Change Password", "Password has been changed.", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Change Password", "Password Change failed.", "Ok");
            }
        }
    }
}