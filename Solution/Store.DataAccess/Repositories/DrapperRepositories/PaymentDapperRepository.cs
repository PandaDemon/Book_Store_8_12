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
    public class PaymentDapperRepository : IPaymentRepository
    {
        private readonly IConfiguration _config;

        public PaymentDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));


        public void Create(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Payments (PaymentNumber, IsPayed, OrderId) VALUES(@PaymentNumber, @IsPayed, @OrderId)";

                conn.Execute(sQuery, item);
            }
        }

        public void Update(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Payments SET PaymentNumber = @PaymentNumber, IsPayed = @IsPayed, OrderId = @OrderId WHERE ID = @Id";

                conn.Execute(sQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Currencies WHERE ID = @id";

                conn.Execute(sQuery, new { id });
            }
        }

        public Payment Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Payments WHERE ID = @id";

                return conn.Query<Payment>(sQuery, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Payments";

                return conn.Query<Payment>(sQuery);
            }
        }
    }
}
