using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
			_roleManager = roleManager;
			_userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<UserModel> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _userManager.GetRolesAsync(user);
            var userFromBase = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Role = role
            };
            return userFromBase;
        }

        public async Task<UserModel> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            var userFromBase = new UserModel
            {
                Id = user.Id,
                AvatarUrl = user.AvatarUrl,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = role
            };
            return userFromBase;
        }

        public async Task<IdentityResult> Create(UserCreateModel сreateUserModel)
        {
            var user = new User { Email = сreateUserModel.Email, PasswordHash = сreateUserModel.PasswordHash, UserName = сreateUserModel.Email, FirstName = сreateUserModel.FirstName, LastName = сreateUserModel.LastName };
            return await _userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> Update(UserEditModel userEditModel)
        {
            User user = await _userManager.FindByIdAsync(userEditModel.Id);

            user.Email = (userEditModel.Email == null) ? user.Email : userEditModel.Email;
            user.FirstName = (userEditModel.FirstName == null) ? user.FirstName : userEditModel.FirstName;
            user.LastName = (userEditModel.LastName == null) ? user.LastName : userEditModel.LastName;
            user.UserName = (userEditModel.Email == null) ? user.Email : userEditModel.Email;

            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<IdentityResult> Delete(string id)
        {
            IdentityResult result = new IdentityResult();

            var user = await _userManager.FindByEmailAsync(id);

            if (user != null)
            {
                result = await _userManager.DeleteAsync(user);
            }
            return result;
        }

        public async Task<IdentityResult> ChangePassword(UserChangePasswordModel changePasswordModel)
        {
            User user = await _userManager.FindByIdAsync(changePasswordModel.Id);
            return await _userManager.ChangePasswordAsync(user, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var userModels = new List<UserModel>();
            var list = _userManager.Users;
            foreach (var user in list)
            {
                var role = await _userManager.GetRolesAsync(user);
                userModels.Add(new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = role
                });
            }
            return userModels;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserSignUpModel сreateUserModel)
        {
            var user = await _userManager.FindByEmailAsync(сreateUserModel.Email);
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> SignUp(UserSignUpModel model)
        {
			var role = _roleManager.Roles;
			var result = new IdentityResult();
            var user = new User { Email = model.Email, PasswordHash = model.Password, UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName };
            try
            {
				
                result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, role.FirstOrDefault(x=> x.Name=="user").Name);

            }
            catch (Exception ex)
            {
                var s = ex;
            }
            return result;
        }

        public async Task<IdentityResult> ConfirmEmail(UserModel model, string code)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            return await _userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<bool> IsEmailConfirmedAsync(UserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public Task<bool> ConfirmTokens(UserModel user, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(UserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(UserModel model, string code, string password)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            return await _userManager.ResetPasswordAsync(user, code, password);
        }

        public async Task<Object> SignInAsync(UserSignInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);



			if (await _userManager.IsEmailConfirmedAsync(user) && result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                var userModel = _mapper.Map<UserModel>(user);
                userModel.Role = await _userManager.GetRolesAsync(user);
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(JwtProvider.JwtProvider.GenerateSecurityDescriptorForRefreshToken(userModel));
                var accessToken = tokenHandler.WriteToken(securityToken);

                var securityTokenRefresh = tokenHandler.CreateToken(JwtProvider.JwtProvider.GenerateSecurityDescriptorForRefreshToken(userModel));
                var refreshToken = tokenHandler.WriteToken(securityTokenRefresh);
                await _userManager.SetAuthenticationTokenAsync(user, "http://localhost:44350", "refreshToken", refreshToken);

                return new TokenModel { AccessToken = accessToken, RefreshToken = refreshToken };
            }

            return null;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RefreshToken(string refreshToken, UserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            await _userManager.SetAuthenticationTokenAsync(user, "http://localhost:56189", "refreshToken", refreshToken);
        }
    }
}
