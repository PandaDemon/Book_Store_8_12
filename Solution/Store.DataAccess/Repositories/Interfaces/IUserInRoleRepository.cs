using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserInRoleRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
    }
}
