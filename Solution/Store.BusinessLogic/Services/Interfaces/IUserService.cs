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
        Task<IdentityResult> CreateAsync(UserCreateModel сreateUserModel);
        Task Edit(UserEditModel editUserModel);
        Task DeleteAsync(string email);
        Task ChangePassword(UserChangePasswordModel changePasswordModel);
        IEnumerable<UserModel> GetAll();
        Task<string> GenerateEmailConfirmationTokenAsync(UserRegisterModel сreateUserModel);
        bool IsUserExist(UserEditModel editUserModel);
        Task<IdentityResult> Register(UserRegisterModel model);
        Task<IdentityResult> ConfirmEmail(UserModel user, string code);
        Task<bool> IsEmailConfirmedAsync(UserModel user);

        Task<ClaimsIdentity> GetIdentityAsync(string username, string password);
        Task<bool> ConfirmTokens(UserModel user, string refreshToken);

        Task<string> GeneratePasswordResetTokenAsync(UserModel user);
        Task<IdentityResult> ResetPasswordAsync(UserModel user, string code, string password);

        Task<SignInResult> SignInAsync(UserLoginModel user);
        Task SignOutAsync();
    }
}
