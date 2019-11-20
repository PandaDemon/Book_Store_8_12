using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Base;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class CurrencyRepository : BaseEFRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(StoreDBContext context) : base(context)
        {
        }
    }
}
