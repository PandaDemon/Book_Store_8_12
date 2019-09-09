using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IRole
    {
        IEnumerable<IdentityRole> GetAll();
        IdentityRole Get(string id);
        void Create(IdentityRole item);
        void Update(IdentityRole item);
        void Delete(string id);

        IEnumerable<IdentityRole> FindByUser(User user);
    }
}
