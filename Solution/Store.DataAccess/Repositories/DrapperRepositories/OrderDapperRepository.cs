using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class OrderDapperRepository : BaseDapperRepository<Order>, IOrderRepository
    {
        public OrderDapperRepository(IConfiguration config) : base(config)
        {
        }
    }
}
