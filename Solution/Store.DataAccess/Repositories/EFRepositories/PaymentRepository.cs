using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class PaymentRepository : BaseEFRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
