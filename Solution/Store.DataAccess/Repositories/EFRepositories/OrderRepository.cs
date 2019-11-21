using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
