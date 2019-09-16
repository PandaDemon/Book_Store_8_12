using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface ICurrencyRepository : IBaseRepository<Currency>
    {
        IEnumerable<Currency> Find(Func<Currency, Boolean> predicate);
    }
}
