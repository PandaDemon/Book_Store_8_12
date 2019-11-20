using Microsoft.AspNetCore.Identity;
using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserViewModel> FindByEmailAsync(string email);
        Task<ApplicationUserViewModel> FindUserByIdAsync(string id);
        Task<IdentityResult> CreateUserAsync(CreateUserViewModel сreateUserViewModel);
        Task<IdentityResult> EditApplicationUser(EditUserViewModel editUserViewModel);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel changePasswordViewModel);
        Task<IEnumerable<ApplicationUserViewModel>> GetAllAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(RegisterUserViewModel сreateUserViewModel);
        Task<IdentityResult> RegisterUser(RegisterUserViewModel model);
        Task<IdentityResult> ConfirmEmail(ApplicationUserViewModel user, string code);
        Task<bool> IsEmailConfirmedAsync(ApplicationUserViewModel user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUserViewModel user);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUserViewModel user, string code, string password);
        Task<TokenResponseModel> SignInAsync(LoginViewModel user);
        Task SignOutAsync();
        Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByFirstName(SortOrder sortType);
        Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByLastName(SortOrder sortType);
    }
}
