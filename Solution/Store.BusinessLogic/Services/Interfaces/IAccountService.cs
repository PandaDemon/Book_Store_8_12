using Store.BusinessLogic.Models.User;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
	public interface IAccountService
	{
		Task<string> RegisterAsync(UserModel model);
		Task<string> LogInAsync(string email, string password);
		Task LogOutAsync();
		Task<string> ForgotPasswordAsync(string userEmail);
		Task<bool> ChangePasswordAsync(UserModel model);
		Task<string> ConfirmEmailAsync(string userId, string confirmationToken);
		Task<bool> EditProfileAsync(UserModel userProfile);
	}
}
