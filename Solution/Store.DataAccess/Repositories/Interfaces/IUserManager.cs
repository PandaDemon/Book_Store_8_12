using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserManager
    {
        Task FindByNameAsync(string username);
        Task CheckPasswordAsync(User user, string password);
        Task CreateAsync(User user, string password);
    }
}
