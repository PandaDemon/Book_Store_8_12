using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        IEnumerable<Payment> FindByOrder(Func<Payment, Boolean> predicate);
    }
}
