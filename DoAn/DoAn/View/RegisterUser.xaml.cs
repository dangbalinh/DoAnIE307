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

    public class RegisterInFo{
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterInFo(string email = "", string password = "", string name = "", string confirmPassword = "")
        {
            Email = email;
            Password = password;
            Name = name;
            ConfirmPassword = confirmPassword;
        }
        
    }
    public partial class RegisterUser : ContentPage
    {

        IAuth auth;
        RegisterInFo registerInFo = new RegisterInFo();
        public RegisterUser()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            BindingContext = registerInFo;
            dataForm.DataObject = registerInFo;
            dataForm.ValidateProperty += dataForm_ValidateProperty;

        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(registerInFo.Name))
                {
                    await DisplayAlert("Warning", "Type name", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(registerInFo.Email))
                {
                    await DisplayAlert("Warning", "Type email", "Ok");
                    return;
                }
                if (registerInFo.Password.Length < 6)
                {
                    await DisplayAlert("Warning", "Password should be 6 digit.", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(registerInFo.Password))
                {
                    await DisplayAlert("Warning", "Type password", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(registerInFo.ConfirmPassword))
                {
                    await DisplayAlert("Warning", "Type Confirm password", "Ok");
                    return;
                }
                if (registerInFo.Password != registerInFo.ConfirmPassword)
                {
                    await DisplayAlert("Warning", "Password not match.", "Ok");
                    return;
                }

                //bool isSave = await _userRepository.Register(email, name, password);
                //if (isSave)
                //{
                //    await DisplayAlert("Register user", "Registration completed", "Ok");
                //    await Navigation.PopModalAsync();
                //}
                //else
                //{
                //    await DisplayAlert("Register user", "Registration failed", "Ok");
                //}

                var user = auth.RegisterAsync(registerInFo.Email, registerInFo.Password, registerInFo.Name);
                if (user != null)
                {
                    var signOut = auth.SignOutAsync();
                    if (signOut)
                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Warning", "Email exist", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "Ok");
                }

            }
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }


        void dataForm_ValidateProperty(System.Object sender, DevExpress.XamarinForms.DataForm.DataFormPropertyValidationEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    // name must be >= 3 characters
                    if (e.NewValue.ToString().Length < 3)
                    {
                        e.HasError = true;
                        e.ErrorText = "The name should contain more than 2 characters.";
                    }
                    registerInFo.Name = e.NewValue.ToString();
                    break;
                case "Email":
                    // validate email using regular expression
                    if (!System.Text.RegularExpressions.Regex.IsMatch(e.NewValue.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        e.HasError = true;
                        e.ErrorText = "The email address is not valid.";
                    }
                    registerInFo.Email = e.NewValue.ToString();
                    break;
                case "Password":
                    // password must be >= 6 characters
                    if (e.NewValue.ToString().Length < 6)
                    {
                        e.HasError = true;
                        e.ErrorText = "The password should contain more than 5 characters.";
                    }
                    registerInFo.Password = e.NewValue.ToString();
                    break;
                case "ConfirmPassword":
                    // password must be >= 6 characters
                    if (e.NewValue.ToString().Length < 6)
                    {
                        e.HasError = true;
                        e.ErrorText = "The password should contain more than 5 characters.";
                    }

                    // password and confirm password must match
                    if (registerInFo.Password != e.NewValue.ToString())
                    {
                        e.HasError = true;
                        e.ErrorText = "The password and confirm password do not match.";
                    }

                    registerInFo.ConfirmPassword = e.NewValue.ToString();
                    break;

            }
        }
    }
}