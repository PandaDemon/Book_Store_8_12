using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        Task<User> GetAsync(string id);
        Task<User> FindByEmailAsync(string email);
        Task<IdentityResult> Create(User item);
        Task UpdateAsync(User item);
        Task Delete(string id);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmail(User user, string code);
        Task<bool> IsEmailConfirmed(User user);
    }
}