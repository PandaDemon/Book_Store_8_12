using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PrintStore.BusinessLogic.Helpers.Interface;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly IJwtHelper _jwtHelper;
        private readonly IMapper _mapper;

        public ApplicationUserService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            JwtSecurityTokenHandler jwtSecurityTokenHandler,
            IJwtHelper jwtHelper,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        public async Task<ApplicationUserViewModel> FindByEmailAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            IList<string> role = await _userManager.GetRolesAsync(user);

            ApplicationUserViewModel userFromBase = new ApplicationUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleName = role
            };

            return userFromBase;
        }

        public async Task<ApplicationUserViewModel> FindUserByIdAsync(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            IList<string> role = await _userManager.GetRolesAsync(user);

            if (user != null)
            {
                ApplicationUserViewModel userFromBase = new ApplicationUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleName = role
                };

                return userFromBase;
            }

            return null;
        }

        public async Task<IdentityResult> CreateUserAsync(CreateUserViewModel сreateUserViewModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(сreateUserViewModel);        
            IdentityResult result = await _userManager.CreateAsync(user, сreateUserViewModel.Password);

            await _userManager.AddToRoleAsync(user, "user");

            return result;
        }

        public async Task<IdentityResult> EditApplicationUser(EditUserViewModel editUserViewModel)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(editUserViewModel);
            IdentityResult result = await _userManager.UpdateAsync(user);

            return result;

        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            IdentityResult result = new IdentityResult();
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                result = await _userManager.DeleteAsync(user);
            }

            return result;
        }

        public async Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel changePasswordViewModel)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(changePasswordViewModel.Id);

            return await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.ConfirmNewPassword);

        }

        public async Task<IEnumerable<ApplicationUserViewModel>> GetAllAsync()
        {           
            IEnumerable<ApplicationUser> listOfUsers = _userManager.Users;

            List<ApplicationUserViewModel> applicationUserViewModels = await UserViewModelCreateAsync(listOfUsers);

            return applicationUserViewModels;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(RegisterUserViewModel сreateUserViewModel)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(сreateUserViewModel.Email);

            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> RegisterUser(RegisterUserViewModel model)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(model);
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            await _userManager.AddToRoleAsync(user, "user");

            return result;
        }

        public async Task<IdentityResult> ConfirmEmail(ApplicationUserViewModel model, string code)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            return await _userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUserViewModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUserViewModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUserViewModel model, string code, string password)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

            return await _userManager.ResetPasswordAsync(user, code, password);
        }

        public async Task<TokenResponseModel> SignInAsync(LoginViewModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            
            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

            if (await _userManager.IsEmailConfirmedAsync(user) && result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);

                ApplicationUserViewModel userModel = _mapper.Map<ApplicationUserViewModel>(user);
                userModel.RoleName = await _userManager.GetRolesAsync(user);

                return CreateTokens(userModel);
            }

            return null;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }        

        public async Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByFirstName(SortOrder sortType)
        {
            IEnumerable<ApplicationUser> listOfUsers = new List<ApplicationUser>();

            if (sortType == SortOrder.Ascending)
            {
                listOfUsers = _userManager.Users.OrderBy(user => user.FirstName);
            }
            if (sortType == SortOrder.Descending)
            {
                listOfUsers = _userManager.Users.OrderByDescending(user => user.FirstName);
            }

            List<ApplicationUserViewModel> applicationUserViewModels = await UserViewModelCreateAsync(listOfUsers);

            return applicationUserViewModels;
        }

        public async Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByLastName(SortOrder sortType)
        {
            IEnumerable<ApplicationUser> listOfUsers = new List<ApplicationUser>();

            if (sortType == SortOrder.Ascending)
            {
                listOfUsers = _userManager.Users.OrderBy(user => user.LastName);
            }
            if (sortType == SortOrder.Descending)
            {
                listOfUsers = _userManager.Users.OrderByDescending(user => user.LastName);
            }

            List<ApplicationUserViewModel> applicationUserViewModels = await UserViewModelCreateAsync(listOfUsers);            

            return applicationUserViewModels;
        }

        private async Task<List<ApplicationUserViewModel>> UserViewModelCreateAsync(IEnumerable<ApplicationUser> listOfUsers)
        {
            List<ApplicationUserViewModel> applicationUserViewModels = new List<ApplicationUserViewModel>();
            foreach (ApplicationUser user in listOfUsers)
            {
                IList<string> role = await _userManager.GetRolesAsync(user);
                applicationUserViewModels.Add(new ApplicationUserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleName = role
                });
            }

            return applicationUserViewModels;
        }

        private TokenResponseModel CreateTokens(ApplicationUserViewModel userModel)
        {
            SecurityToken securityTokenAccess = _jwtSecurityTokenHandler.CreateToken(_jwtHelper.GenerateSecurityTokenDescriptor(userModel));
            string accessToken = _jwtSecurityTokenHandler.WriteToken(securityTokenAccess);

            SecurityToken securityTokenRefresh = _jwtSecurityTokenHandler.CreateToken(_jwtHelper.GenerateSecurityDescriptorForRefreshToken(userModel));
            string refreshToken = _jwtSecurityTokenHandler.WriteToken(securityTokenRefresh);

            return new TokenResponseModel { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}
