using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Interfaces;

namespace DoAn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        IAuth auth;
        //UserRepository _userRepository = new UserRepository();

        public ForgotPasswordPage()
        {
            InitializeComponent();
            auth = DependencyService.Resolve<IAuth>();
            //auth = DependencyService.Get<IAuth>();
        }

        //private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        //{
        //    string email = TxtEmail.Text;
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        await DisplayAlert("Warning", "Please enter your email.", "Ok");
        //        return;
        //    }

        //    bool isSend = await _userRepository.ResetPassword(email);
        //    if (isSend)
        //    {
        //        await DisplayAlert("Reset Password", "Send link in your email.", "Ok");
        //        //await Navigation.PopModalAsync();
        //    }
        //    else
        //    {
        //        await DisplayAlert("Reset Password", "Link send failed.", "Ok");
        //    }
        //}

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Please enter your email.", "Ok");
                return;
            }

            if (await auth.ResetPasswordAsync(email))
                await DisplayAlert("Reset Password", "Send link in your email.", "Ok");
            else
                await DisplayAlert("Reset Password", "Link send failed.", "Ok");

        }
    }
}