using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        IEnumerable<Order> FindByUser(Func<Order, Boolean> predicate);
        void Create(Order item);
        void Update(Order item);
        void Delete(int id);
    }
}
