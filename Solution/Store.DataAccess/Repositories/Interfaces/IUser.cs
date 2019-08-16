using Store.DataAccess.Repositories.EFRepositories;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUser
    {
        IEnumerable<UserRepository> GetAll();
        UserRepository Get(int id);
        IEnumerable<UserRepository> Find(Func<UserRepository, Boolean> predicate);
        void Create(UserRepository item);
        void Update(UserRepository item);
        void Delete(int id);
    }
}
