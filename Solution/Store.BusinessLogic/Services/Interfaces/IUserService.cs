using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.User;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> FindByEmailAsync(string email);
        Task<UserModel> FindUserByIdAsync(string id);
        Task<IdentityResult> CreateUserAsync(CreateUserModel сreateUserViewModel);
        Task EditApplicationUser(EditUserModel editUserViewModel);
        Task DeleteUserAsync(string email);
        Task ChangeUserPassword(ChangePasswordModel changePasswordViewModel);
        IEnumerable<UserModel> GetAll();
        Task<string> GenerateEmailConfirmationTokenAsync(RegisterUserModel сreateUserViewModel);
        bool IsUserExist(EditUserModel editUserViewModel);
        Task<IdentityResult> RegisterUser(RegisterUserModel model);
        Task<IdentityResult> ConfirmEmail(UserModel user, string code);
        Task<bool> IsEmailConfirmedAsync(UserModel user);

        Task<ClaimsIdentity> GetIdentityAsync(string username, string password);
        Task<bool> ConfirmTokens(UserModel user, string refreshToken);

        Task<string> GeneratePasswordResetTokenAsync(UserModel user);
        Task<IdentityResult> ResetPasswordAsync(UserModel user, string code, string password);

        Task<SignInResult> SignInAsync(LoginUserModel user);
        Task SignOutAsync();
    }
}
