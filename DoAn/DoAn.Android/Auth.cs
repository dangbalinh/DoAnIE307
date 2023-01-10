using System;
using DoAn.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using Android.Gms.Extensions;
using static Java.Util.Jar.Attributes;
using DoAn.Droid;
using System.Collections.Generic;
using DoAn.Services;
using DoAn.Model;
using DoAn.View;

[assembly : Dependency(typeof(Auth))]
namespace DoAn.Droid
{
	public class Auth: IAuth
	{
		UserService userService = new UserService();

		public string GetEmail()
		{
			// get email from firebase
			var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
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
                var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdToken(false);

                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
            catch (FirebaseAuthUserCollisionException e)
            {
                e.PrintStackTrace();
                return string.Empty;
            }
        }

		public async Task<string> RegisterAsync(string email, string password, string name)
		{
			try{
				var user = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
				var token = await user.User.GetIdToken(false);

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

                return (string)token;
			} catch (FirebaseAuthInvalidUserException e)
			{
				e.PrintStackTrace();
				return string.Empty;
			} catch (FirebaseAuthInvalidCredentialsException e)
			{
				e.PrintStackTrace();
				return string.Empty;
			} catch (FirebaseAuthUserCollisionException e)
			{
				e.PrintStackTrace();
				return string.Empty;
			}

		}

		public bool SignOutAsync()
		{
			try
			{
				Firebase.Auth.FirebaseAuth.Instance.SignOut();
				return true;
			} catch(Exception e)
			{
				return false;
			}
		}

		public bool IsLoggedInAsync()
		{
			var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
			return user != null;
		}

        // forgot password, send link reset password to email
        public async Task<bool> ResetPasswordAsync(string email)
        {
			// send link reset password to the provided email address while the user is NOT logged in
			try
			{
				//await DependencyService.Resolve<IAuth>().ResetPasswordAsync(email);
				await Firebase.Auth.FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
				return true;
			} catch (FirebaseAuthInvalidUserException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthInvalidCredentialsException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthUserCollisionException e)
			{
				e.PrintStackTrace();
				return false;
			}
        }

        // change password
        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
		{
			try
			{
				var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, oldPassword);
				await user.User.UpdatePasswordAsync(newPassword);
				return true;
			} catch (FirebaseAuthInvalidUserException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthInvalidCredentialsException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthUserCollisionException e)
			{
				e.PrintStackTrace();
				return false;
			}
		}

        // check if a string matches the user password
		public async Task<bool> CheckPasswordAsync(string password)
		{
			try
			{
				var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
				var check = await LoginAsync(user.Email, password);
				if (check != string.Empty)
					return true;
                return false;
			} catch (FirebaseAuthInvalidUserException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthInvalidCredentialsException e)
			{
				e.PrintStackTrace();
				return false;
			} catch (FirebaseAuthUserCollisionException e)
			{
				e.PrintStackTrace();
				return false;
			}
		}

        // delete account if user want to
        public async Task<bool> DeleteAccountAsync()
        {
            try
            {
                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;

				// signout current user
                if (SignOutAsync())
                    Application.Current.MainPage = new NavigationPage(new BeginningPage());

                // delete user from firebase realtime database
                await userService.DeleteAccount(user.Email);

                await user.DeleteAsync();
                return true;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return false;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return false;
            }
            catch (FirebaseAuthUserCollisionException e)
            {
                e.PrintStackTrace();
                return false;
            }
        }
    }
}

