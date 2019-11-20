using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Base;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDBContext context) : base(context)
        {
        }
    }
}
