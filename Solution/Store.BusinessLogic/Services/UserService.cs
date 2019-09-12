using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<UserModel> FindByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var userFromBase = new UserModel
            {
                Id = user.Id,
                Email = user.Email
            };
            return userFromBase;
        }

        public async Task<UserModel> FindByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var userFromBase = new UserModel
            {
                Id = user.Id,
                Image = user.Img,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userFromBase;
        }

        public async Task<IdentityResult> CreateAsync(UserCreateModel сreateUserModel)
        {
            var user = new User { Email = сreateUserModel.Email, PasswordHash = сreateUserModel.PasswordHash, UserName = сreateUserModel.Email, FirstName = сreateUserModel.FirstName, LastName = сreateUserModel.LastName };
            return await userManager.CreateAsync(user);
        }

        public async Task Edit(UserEditModel editUserViewModel)
        {
            var user = new User
            {
                Id = editUserViewModel.Id,
                Img = editUserViewModel.Image,
                Email = editUserViewModel.Email,
                FirstName = editUserViewModel.FirstName,
                LastName = editUserViewModel.LastName
            };
            await userManager.UpdateAsync(user);
        }

        public async Task DeleteAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }

        }

        public async Task ChangePassword(UserChangePasswordModel changePasswordViewModel)
        {
            var user = new User
            {
                Email = changePasswordViewModel.Email,
                PasswordHash = changePasswordViewModel.NewPassword
            };
            await userManager.UpdateAsync(user);
        }

        public bool IsUserExist(UserEditModel editUserModel)
        {
            if (userManager.FindByEmailAsync(editUserModel.Email) != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<UserModel> GetAll()
        {
            var userModels = new List<UserModel>();
            var list = userManager.Users;

            foreach (var user in list)
            {
                userModels.Add(new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Image = user.Img
                });
            }
            return userModels;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserRegisterModel сreateUserViewModel)
        {
            var user = await userManager.FindByEmailAsync(сreateUserViewModel.Email);
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> Register(UserRegisterModel model)
        {
            var user = new User { Email = model.Email, PasswordHash = model.Password, UserName = model.Email };
            return await userManager.CreateAsync(user, model.Password);
        }

        public async Task<IdentityResult> ConfirmEmail(UserModel model, string code)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            return await userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<bool> IsEmailConfirmedAsync(UserModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            return await userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var person = await userManager.FindByEmailAsync(username);
            if (person != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName)
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        public Task<bool> FindTokenByUserName(UserModel model, string refreshToken)
        {
            return null;
        }

        public void DeleteToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GeneratePasswordResetTokenAsync(UserModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            return await userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(UserModel model, string code, string password)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            return await userManager.ResetPasswordAsync(user, code, password);
        }

        public Task<bool> ConfirmTokens(UserModel user, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> SignInAsync(UserLoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded && await userManager.IsEmailConfirmedAsync(user))
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public Task CreateToken(JwtSecurityToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
