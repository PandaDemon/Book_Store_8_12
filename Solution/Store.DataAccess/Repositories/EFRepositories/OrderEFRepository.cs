using System;
using System.Collections.Generic;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class OrderEFRepository : IOrderRepository
    {
        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FindByUser(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Order Get(Order item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
