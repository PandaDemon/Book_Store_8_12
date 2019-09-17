using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class OrderEFRepository : IOrderRepository
    {
        private readonly DataBaseContext _context;

        public OrderEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Update(Order item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Order item)
        {
            Order order = _context.Orders.Find(item);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> FindByUser(Func<Order, bool> predicate)
        {
            return _context.Orders.Include(o => o.UserId).Where(predicate).ToList();
        }

        public Order Get(Order item)
        {
            return _context.Orders.Find(item);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }
    }
}
