using Store.BusinessLogic.Common;
using Store.BusinessLogic.Mapper;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
	public class AccountService : IAccountService
	{
		private readonly IUserRepository _userRepository;

		public AccountService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<string> RegisterAsync(UserModel model)
		{
			var user = UserMapperProfile.MapModelToEntity(model);
			var confirmationToken = await _userRepository.RegisterAsync(user, model.Password);
			if (string.IsNullOrWhiteSpace(confirmationToken))
			{
				return confirmationToken;
			}
			return string.Empty;
		}

		public async Task<string> ConfirmEmailAsync(string email, string confirmationToken)
		{
			if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(confirmationToken))
			{
				return await _userRepository.ConfirmEmailAsync(email, confirmationToken);
			}
			return string.Empty;
		}

		public async Task<string> LogInAsync(string email, string password)
		{
			if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
			{
				return "Input is empty";
			}
			
			var userId = await _userRepository.LogInAsync(email, password);
			if (!string.IsNullOrWhiteSpace(userId))
			{
				return userId;
			}
			return "Input isn't correct";
		}

		public async Task LogOutAsync()
		{
			await _userRepository.LogOutAsync();
		}

		public async Task<string> ForgotPasswordAsync(string email)
		{
			if (!string.IsNullOrWhiteSpace(email))
			{
				var newPassword = GeneratePassword.PasswordGenerate(GeneratePassword.PasswordLength);
				await _userRepository.ForgotPasswordAsync(email, newPassword);
				return newPassword;
			}
			return "Input is empty";
		}

		public async Task<bool> ChangePasswordAsync(UserModel model)
		{
			var user = UserMapperProfile.MapModelToEntity(model);
			return await _userRepository.ChangePasswordAsync(user, model.Password);
		}

		public async Task<bool> EditProfileAsync(UserModel userProfile)
		{
			if (!string.IsNullOrWhiteSpace(userProfile.Password))
			{
				await ChangePasswordAsync(userProfile);
			}
			return await _userRepository.EditProfileAsync(UserMapperProfile.MapModelToEntity(userProfile));
		}
	}
}
