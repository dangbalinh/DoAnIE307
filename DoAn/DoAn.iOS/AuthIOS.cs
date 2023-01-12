using System;
using DoAn.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using DoAn.iOS;
using Foundation;
using DoAn.Services;
using DoAn.View;

[ assembly : Dependency(typeof(AuthIOS))]
namespace DoAn.iOS
{
	public class AuthIOS : IAuth
	{
		UserService userService = new UserService();

		public string GetEmail()
		{
			// get email from firebase
			var user = Auth.DefaultInstance.CurrentUser;
			if (user != null)
			{
				return user.Email;
			}
			return string.Empty;
		}

		public async Task<string> LoginAsync(string email, string password)
		{
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);

                return await user.User.GetIdTokenAsync(false);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

		public async Task<string> RegisterAsync(string email, string password, string name)
		{
			try{
				var user = await Auth.DefaultInstance.CreateUserAsync(email, password);

                // add user to firebase realtime database
                DoAn.Model.User newUser = new DoAn.Model.User()
                {
                    name = name,
                    email = email,
                    phone = "",
                    address = "",
                    img = "user.png",
                };
                await userService.SaveUser(newUser);

                return await user.User.GetIdTokenAsync(false);
			} catch (Exception e)
			{
				return string.Empty;
			}
		}

		public bool SignOutAsync()
		{
			try
			{
				_ = Auth.DefaultInstance.SignOut(out NSError error);
				return error == null;
			} catch (Exception e)
			{
				return false;
			}
		}

		public bool IsLoggedInAsync()
		{
            var user = Auth.DefaultInstance.CurrentUser;
            return user != null;
        }

		// forgot password, send link reset password to email
		public async Task<bool> ResetPasswordAsync(string email)
		{
			try
			{
				await Auth.DefaultInstance.SendPasswordResetAsync(email);
				return true;
			} catch (Exception e)
			{
				return false;
			}
		}

		// change password
		public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
		{
			try
			{
				var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, oldPassword);
				await user.User.UpdatePasswordAsync(newPassword);
				return true;
			} catch (Exception e)
			{
				return false;
			}
		}

		// check if a string matches the user's password
		public async Task<bool> CheckPasswordAsync(string password)
		{
			try
			{
				var user = Auth.DefaultInstance.CurrentUser;

                var check = await Auth.DefaultInstance.SignInWithPasswordAsync(user.Email, password);
				return user != null;
			} catch (Exception e)
			{
				return false;
			}
		}

        // delete user account if user want to
        public async Task<bool> DeleteAccountAsync()
        {
            try
            {
                var user = Auth.DefaultInstance.CurrentUser;

                // signout current user and navigate to beginning page
                if (SignOutAsync())
					App.Current.MainPage = new NavigationPage(new BeginningPage());


                // delete user from firebase realtime database
                await userService.DeleteAccount(user.Email);
                await user.DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

		public	bool IsUserExist(string email){
			// check if a user with the provided email address exists
			var user = userService.GetUser(email);
			if (user != null)
				return true;
			return false;
		}
    }
}

