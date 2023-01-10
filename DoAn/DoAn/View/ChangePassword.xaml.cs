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
using Xamarin.CommunityToolkit.Extensions;
using DoAn.PopupPages;
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
            try
            {
                // check if the current password is correct
                if (!(await auth.CheckPasswordAsync(changePasswordInFo.CurrentPassword)))
                {
                    Navigation.ShowPopup(new FailedActionPopup("Current password is incorrect"));
                    return;
                }

                // check if the new password is valid
                if (changePasswordInFo.NewPassword != changePasswordInFo.ConfirmPassword)
                {
                    Navigation.ShowPopup(new FailedActionPopup("Confirm password do not match password"));
                    return;
                }
                else if (changePasswordInFo.NewPassword.Length < 6)
                {
                    Navigation.ShowPopup(new FailedActionPopup("Password must be at least 6 characters"));
                    return;
                }
                else if (changePasswordInFo.NewPassword == changePasswordInFo.CurrentPassword)
                {
                    Navigation.ShowPopup(new FailedActionPopup("New password must be different from current password"));
                    return;
                }

                // change password
                if (await auth.ChangePasswordAsync(auth.GetEmail(), changePasswordInFo.CurrentPassword, changePasswordInFo.NewPassword))
                {
                    Navigation.ShowPopup(new SuccessPopup("Password has been changed"));
                    await Navigation.PopAsync();
                }
                else
                    Navigation.ShowPopup(new FailedActionPopup("Password Change failed"));
            } catch (Exception ex)
            {
                Navigation.ShowPopup(new FailedActionPopup($"Error: {ex.Message}"));

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