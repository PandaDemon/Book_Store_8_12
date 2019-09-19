using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PaymentEFRepository : BaseEFRepository<Payment>, IPaymentRepository
    {
        public PaymentEFRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
