using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> FindByEmailAsync(string email);
        Task<UserModel> FindByIdAsync(string id);
        Task<IdentityResult> Create(UserCreateModel сreateUserModel);
        Task<IdentityResult> Update(UserEditModel updateUserModel);
        Task<IdentityResult> Delete(string id);
        Task<IdentityResult> ChangePassword(UserChangePasswordModel changePasswordModel);
        Task<IEnumerable<UserModel>> GetAll();
        Task<string> GenerateEmailConfirmationTokenAsync(UserSignUpModel сreateUserModel);

        Task<IdentityResult> SignUp(UserSignUpModel model);
        Task<IdentityResult> ConfirmEmail(UserModel user, string code);
        Task<bool> IsEmailConfirmedAsync(UserModel user);
        Task<bool> ConfirmTokens(UserModel user, string refreshToken);
        Task<string> GeneratePasswordResetTokenAsync(UserModel user);
        Task<IdentityResult> ResetPasswordAsync(UserModel user, string code, string password);
        Task<Object> SignInAsync(UserSignInModel user);
        Task LogOutAsync();
        Task RefreshToken(string refreshToken, UserModel model);
    }
}
