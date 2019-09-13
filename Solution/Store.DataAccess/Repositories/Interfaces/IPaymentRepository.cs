using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAll();
        Payment Get(int id);
        IEnumerable<Payment> FindByOrder(Func<Payment, Boolean> predicate);
        void Create(Payment item);
        void Update(Payment item);
        void Delete(int id);
    }
}
