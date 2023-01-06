using System;
using System.Collections.Generic;
using DoAn.Interfaces;
using DoAn.Services;
using DoAn.Model;

using Xamarin.Forms;

namespace DoAn.OriginalPage.User
{
    public partial class EditProfilePage : ContentPage
    {
        readonly IAuth auth;
        UserService userService = new UserService();
        public class UserInfo
        {
            public string Name { get; set; }
            //public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            // Password;
            public UserInfo(Model.User user)
            {
                Name = user.name;
                //Email = user.email;
                Phone = user.phone;
                Address = user.address;
                // Password = user.password;
            }
  
        }

        UserInfo userInfo;
        public EditProfilePage( Model.User user)
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
            BindingContext = user;
            dataForm.DataObject = userInfo = new UserInfo(user);
            dataForm.ValidateProperty += dataForm_ValidateProperty;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            dataForm.DataObject = userInfo;

            DoAn.Model.User user = new DoAn.Model.User()
            {
                name = userInfo.Name,
                email = auth.GetEmail(),
                phone = userInfo.Phone,
                address = userInfo.Address,
                img = "user.png",
            };

            await userService.UpdateUser(user);

            await DisplayAlert("Success", "Your profile has been updated", "OK");
            await Navigation.PopAsync();
        }

        void dataForm_ValidateProperty(System.Object sender, DevExpress.XamarinForms.DataForm.DataFormPropertyValidationEventArgs e)
        {
            // reassing value to dataForm.DataObject


            // all fileds are required
            if (e.NewValue.ToString() == "")
            {
                e.HasError = true;
                e.ErrorText = "This field is required.";
            }

            // password should contain more than 5 characters
            if (e.PropertyName == "Password")
            {
                if (e.NewValue.ToString().Length < 6)
                {
                    e.HasError = true;
                    e.ErrorText = "The password should contain more than 5 characters.";
                }
            }

            switch(e.PropertyName){
                case "Name":
                    userInfo.Name = e.NewValue.ToString();
                    break;
                //case "Email":
                //    if (!System.Text.RegularExpressions.Regex.IsMatch(e.NewValue.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                //    {
                //        e.HasError = true;
                //        e.ErrorText = "The email is not valid.";
                //    }
                //    userInfo.Email = e.NewValue.ToString();
                //    break;
                case "Phone":
                    if (!System.Text.RegularExpressions.Regex.IsMatch(e.NewValue.ToString(), @"^(\+84|0)\d{9}$"))
                    {
                        e.HasError = true;
                        e.ErrorText = "The phone is not valid.";
                    }
                    userInfo.Phone = e.NewValue.ToString();
                    break;
                case "Address":
                    userInfo.Address = e.NewValue.ToString();
                    break;
                
            }
        }

        void dataForm_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // reassign value to dataForm.DataObject on property changed
        }
    }


}

