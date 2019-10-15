using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<bool> UpdateAsync(User user);
		Task<bool> DeleteAsync(User user);
		Task<bool> DeleteByIdAsync(string userId);
		Task<List<User>> GetAllAsync();
		Task<User> GetByIdAsync(string userID);
		Task<User> GetByEmailAsync(string userEmail);
		Task<List<User>> GetAllByEmailAsync(string userEmail, List<User> users);
		Task<List<User>> GetAllByNameAsync(string userName, List<User> users);
		Task<List<User>> GetUsersByLockout(bool isLocked, List<User> users);


		Task<string> LogInAsync(string email, string password);
		Task<string> RegisterAsync(User user, string password);
		Task<string> ConfirmEmailAsync(string userId, string confirmationToken);
		Task LogOutAsync();
		Task<bool> ForgotPasswordAsync(string userEmail, string newPassword);
		Task<bool> ChangePasswordAsync(User user, string newPassword);
		Task<bool> EditProfileAsync(User userProfile);
		Task<bool> BlockUserAsync(User userProfile);
	}
}
