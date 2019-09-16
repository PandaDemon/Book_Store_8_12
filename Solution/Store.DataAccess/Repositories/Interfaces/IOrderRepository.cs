using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> FindByUser(Func<Order, Boolean> predicate);
    }
}
