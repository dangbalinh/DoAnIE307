using System;
using System.Threading.Tasks;
namespace DoAn.Interfaces
{
	public interface IAuth
	{
		string GetEmail();
		// string GetPassword();

		Task<string> LoginAsync(string email, string password);

		Task<string> RegisterAsync(string email, string password, string name);

		bool SignOutAsync();

		bool IsLoggedInAsync();

		// reset password
		Task<bool> ResetPasswordAsync(string email);

		// change password
		Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);

		// check if a string matches the user password
		Task<bool> CheckPasswordAsync(string password);

		// deleting account if user want to
		Task<bool> DeleteAccountAsync();
	}
}

