using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class CurrencyDapperRepository : BaseDapperRepository<Currency>, ICurrencyRepository
    {

        public CurrencyDapperRepository(IConfiguration config) : base(config)
        {
        }
    }
}
