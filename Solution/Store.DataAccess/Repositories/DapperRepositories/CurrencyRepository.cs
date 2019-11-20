using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class CurrencyRepository : BaseDapperRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }
    }
}
