using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DoAn.OriginalPage;
using DoAn.Interfaces;


namespace DoAn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class LoginInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginInfo(string email = "", string password = "")
        {
            Email = email;
            Password = password;
        }
    }


    public partial class LoginPage : ContentPage
    {
        IAuth auth;
        LoginInfo loginInfo = new LoginInfo();

        public LoginPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            BindingContext = loginInfo;
            dataForm.DataObject = loginInfo;
            dataForm.ValidateProperty += dataForm_ValidateProperty;
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(loginInfo.Email))
                {
                    await DisplayAlert("Warning", "Enter your email", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(loginInfo.Password))
                {
                    await DisplayAlert("Warning", "Enter your password", "Ok");
                    return;
                }

                string token = await auth.LoginAsync(loginInfo.Email, loginInfo.Password);
                if (token != string.Empty)
                {
                    Application.Current.MainPage = new NavigationPage(new HomePage());
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Unauthorized", "Email not found", "ok");
                }
                else if (exception.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Unauthorized", "Password incorrect", "ok");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "ok");
                }
            }

        }

        private async void RegisterTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterUser());
        }

        private async void ForgotTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ForgotPasswordPage());
        }

        void dataForm_ValidateProperty(System.Object sender, DevExpress.XamarinForms.DataForm.DataFormPropertyValidationEventArgs e)
        {
            //DisplayAlert("t", e.PropertyName + " - " +e.NewValue, "OK");
            // all fileds are required
            if (e.NewValue.ToString() == "")
            {
                e.HasError = true;
                e.ErrorText = "This field is required.";
            }

            switch (e.PropertyName)
            {
                case "Email":
                    // validate email using regular expression
                    if (!System.Text.RegularExpressions.Regex.IsMatch(e.NewValue.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        e.HasError = true;
                        e.ErrorText = "The email address is not valid.";
                    }
                    loginInfo.Email = e.NewValue.ToString();
                    break;
                case "Password":
                    // password must be >= 6 characters
                    if (e.NewValue.ToString().Length < 6)
                    {
                        e.HasError = true;
                        e.ErrorText = "The password should contain more than 5 characters.";
                    }
                    loginInfo.Password = e.NewValue.ToString();
                    break;

            }
        }
    }
}