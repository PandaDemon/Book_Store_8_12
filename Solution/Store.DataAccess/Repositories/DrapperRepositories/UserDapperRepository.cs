using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class UserDapperRepository : IUserRepository
    {
        private readonly DataBaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserDapperRepository(DataBaseContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> ConfirmEmail(User user, string code)
        {
            User User = await _userManager.FindByEmailAsync(user.Email);
            var result = await _userManager.ConfirmEmailAsync(User, code);
            return result;
        }

        public async Task<IdentityResult> Create(User item)
        {
            var result = await _userManager.CreateAsync(item);
            return result;
        }

        public async Task Delete(string id)
        {
            User User = await _userManager.FindByIdAsync(id);

            if (User != null)
            {
                try
                {
                    var result = await _userManager.DeleteAsync(User);
                }
                catch (Exception exception)
                {
                    var infoException = exception;
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
            user.AvatarUrl = item.AvatarUrl;
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
