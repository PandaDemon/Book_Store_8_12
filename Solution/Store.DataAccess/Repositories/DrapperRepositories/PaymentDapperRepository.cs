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
    public class PaymentDapperRepository : BaseDapperRepository<Payment>, IPaymentRepository
    {

        public PaymentDapperRepository(IConfiguration config) : base(config)
        {
        }
    }
}
