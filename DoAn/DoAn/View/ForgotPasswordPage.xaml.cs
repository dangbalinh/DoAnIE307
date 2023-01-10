using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.Interfaces;
using Xamarin.CommunityToolkit.Extensions;
using DoAn.PopupPages;
using DoAn.Services;

namespace DoAn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        IAuth auth;
        readonly UserService userService;

        public ForgotPasswordPage()
        {
            InitializeComponent();
            auth = DependencyService.Resolve<IAuth>();
            userService = new UserService();
        }

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")){
                // email is not valid
                Navigation.ShowPopup(new FailedActionPopup("Email is not valid"));
                return;
            } else if (await userService.CheckEmail(email))
            {
                // email don't exsist
                Navigation.ShowPopup(new FailedActionPopup("This email di not exsist"));
                return;
            }
            

            if (await auth.ResetPasswordAsync(email))
                Navigation.ShowPopup(new SuccessPopup("Send link in your email"));
            else
                Navigation.ShowPopup(new FailedActionPopup("Link send failed"));


        }
    }
}