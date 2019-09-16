using System;
using System.Collections.Generic;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PaymentEFRepository : IPaymentRepository
    {
        public void Create(Payment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Payment item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> FindByOrder(Func<Payment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Payment Get(Payment item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Payment item)
        {
            throw new NotImplementedException();
        }
    }
}
