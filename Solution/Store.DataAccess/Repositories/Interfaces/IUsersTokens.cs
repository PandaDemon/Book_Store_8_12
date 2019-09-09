using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUsersTokens
    {
        IEnumerable<IdentityUserToken<string>> GetAll();
        IEnumerable<IdentityUserToken<string>> FindByUser(Func<IdentityUserToken<string>, Boolean> predicate);
        void Create(IdentityUserToken<string> item);
        void Update(IdentityUserToken<string> item);
        void Delete(string tokenValue);
        string FindByUserName(string username);
    }
}
