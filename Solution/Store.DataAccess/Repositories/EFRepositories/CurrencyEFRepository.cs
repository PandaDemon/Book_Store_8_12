using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class CurrencyEFRepository : BaseEFRepository<Currency>, ICurrencyRepository
    {
        public CurrencyEFRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
