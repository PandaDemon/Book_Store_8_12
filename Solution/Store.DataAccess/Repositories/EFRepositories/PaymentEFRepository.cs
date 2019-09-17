using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PaymentEFRepository : IPaymentRepository
    {
        private readonly DataBaseContext _context;

        public PaymentEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Payment item)
        {
            _context.Payments.Add(item);
            _context.SaveChanges();
        }

        public void Update(Payment item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Payment item)
        {
            Payment payment = _context.Payments.Find(item);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Payment> FindByOrder(Func<Payment, bool> predicate)
        {
            return _context.Payments.Include(order => order.OrderId).Where(predicate).ToList();
        }

        public Payment Get(Payment item)
        {
            return _context.Payments.Find(item);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments;
        }
    }
}
