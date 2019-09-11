using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class DapperUserRepository : IUser
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;

        public DapperUserRepository(DataBaseContext context, UserManager<User> userManager)
        {
            this._userManager = userManager;
            this._context = context;
        }

        public async Task<IdentityResult> ConfirmEmail(User user, string code)
        {
            User User = await _userManager.FindByEmailAsync(user.Email);
            var result = await _userManager.ConfirmEmailAsync(User, code);
            return result;
        }

        public async Task<IdentityResult> Create(User item)
        {

            var result = await _userManager.CreateAsync(item, item.Password);

            return result;


        }

        public async Task Delete(string id)
        {
            User applicationUser = await _userManager.FindByIdAsync(id);

            if (applicationUser != null)
            {
                try
                {
                    var result = await _userManager.DeleteAsync(applicationUser);
                }
                catch (Exception ex)
                {
                    var e = ex;
                }

            }
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            User applicationUser = await _userManager.FindByEmailAsync(email);
            return applicationUser;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> GetAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }


        public IEnumerable<User> GetAll()
        {
            return _userManager.Users;
        }

        public async Task UpdateAsync(User item)
        {
            User user = _context.Users.Find(item.Id);
            user.Password = item.Password;
            user.Img = item.Img;
            user.LastName = item.LastName;
            user.FirstName = item.FirstName;
            user.Email = item.Email;
            await _userManager.UpdateAsync(user);
        }

        public Task<bool> IsEmailConfirmed(User user)
        {
            return _userManager.IsEmailConfirmedAsync(user);
        }
    }
}
