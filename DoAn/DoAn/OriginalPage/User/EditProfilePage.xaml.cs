using System;
using System.Collections.Generic;
using DoAn.Interfaces;
using DoAn.Services;
using DoAn.Model;

using Xamarin.Forms;
using DevExpress.XamarinForms.DataForm;

namespace DoAn.OriginalPage.User
{
    public partial class EditProfilePage : ContentPage
    {
        readonly IAuth auth;
        readonly UserService userService = new UserService();
        public class UserInfo
        {
            [DataFormDisplayOptions(LabelPosition = DataFormLabelPosition.Top)]
            public string Email { get; set; }

            [DataFormDisplayOptions(LabelPosition = DataFormLabelPosition.Top)]
            public string Name { get; set; }

            [DataFormMaskedEditor(Keyboard = "Telephone")]
            [DataFormDisplayOptions(LabelPosition = DataFormLabelPosition.Top)]
            public string Phone { get; set; }

            [DataFormDisplayOptions(LabelPosition = DataFormLabelPosition.Top)]
            public string Address { get; set; }

            [DataFormDisplayOptions(IsLabelVisible = false)]
            public string Image { get; set; }

            // Password;
            public UserInfo(Model.User user)
            {
                Email = user.email;
                Name = user.name;
                Phone = user.phone;
                Address = user.address;
                Image = user.img;
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

            Model.User user = new Model.User()
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

        void ImgTap_Tapped(System.Object sender, System.EventArgs e)
        {
        }
    }


}

