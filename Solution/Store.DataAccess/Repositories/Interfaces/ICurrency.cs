using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface ICurrency
    {
        IEnumerable<Currency> GetAll();
        Currency Get(int id);
        IEnumerable<Currency> Find(Func<Currency, Boolean> predicate);
        void Create(Currency item);
        void Update(Currency item);
        void Delete(int id);
    }
}
