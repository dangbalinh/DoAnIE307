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
    public class ChangePasswordInFo
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string CurrentPassword { get; set; }
        public ChangePasswordInFo(string newPassword = "", string confirmPassword = "", string currentPassword = "")
        {
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
            CurrentPassword = currentPassword;
        }
    }


    public partial class ChangePassword : ContentPage
    {
        //UserRepository _userRepository = new UserRepository();
        IAuth auth;
        ChangePasswordInFo changePasswordInFo = new ChangePasswordInFo();
        public ChangePassword()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            BindingContext = changePasswordInFo;
            dataForm.DataObject = changePasswordInFo;
            dataForm.ValidateProperty += dataForm_ValidateProperty;
        }

        private async void BtnChangePassword_Clicked(object sender, EventArgs e)
        {
            // check if the current password is correct
            if(!(await auth.CheckPasswordAsync(changePasswordInFo.CurrentPassword)))
            {
                await DisplayAlert("Change Password", "Current password is incorrect", "Ok");
                return;
            }

            // check if the new password is valid
            if (changePasswordInFo.NewPassword != changePasswordInFo.ConfirmPassword)
            {
                await DisplayAlert("Change Password", "Confirm password not match.", "Ok");
                return;
            } else if (changePasswordInFo.NewPassword.Length < 6)
            {
                await DisplayAlert("Change Password", "Password must be at least 6 characters", "Ok");
                return;
            } else if (changePasswordInFo.NewPassword == changePasswordInFo.CurrentPassword)
            {
                await DisplayAlert("Change Password", "New password must be different from current password", "Ok");
                return;
            }

            // change password
            if (await auth.ChangePasswordAsync(auth.GetEmail(), changePasswordInFo.CurrentPassword, changePasswordInFo.NewPassword))
            {
                await DisplayAlert("Change Password", "Password has been changed.", "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Change Password", "Password Change failed.", "Ok");
            }
        }

        void dataForm_ValidateProperty(System.Object sender, DevExpress.XamarinForms.DataForm.DataFormPropertyValidationEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentPassword":
                    if (e.NewValue == null || e.NewValue.ToString().Length < 6)
                    {
                        e.HasError = true;
                        e.ErrorText = "Password must be at least 6 characters";
                    }
                    changePasswordInFo.CurrentPassword = e.NewValue.ToString();
                    break;
                case "NewPassword":
                    if (e.NewValue == null || e.NewValue.ToString().Length < 6)
                    {
                        e.HasError = true;
                        e.ErrorText = "Password must be at least 6 characters";
                    }
                    changePasswordInFo.NewPassword = e.NewValue.ToString();
                    break;
                case "ConfirmPassword":
                    if (e.NewValue == null || e.NewValue.ToString() != changePasswordInFo.NewPassword)
                    {
                        e.HasError = true;
                        e.ErrorText = "Confirm password not match.";
                    }
                    changePasswordInFo.ConfirmPassword = e.NewValue.ToString();
                    break;
            }
        }
    }
}