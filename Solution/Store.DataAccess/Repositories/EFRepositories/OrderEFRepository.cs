using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class OrderEFRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderEFRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
