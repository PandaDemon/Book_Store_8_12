using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class PaymentRepository : BaseDapperRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }
    }
}
