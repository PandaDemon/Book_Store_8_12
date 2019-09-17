using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class PaymentDapperRepository : IPaymentRepository
    {
        private readonly IConfiguration _config;

        public PaymentDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void Create(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Payments (PaymentNumber, IsPayed, OrderId) " +
                    "VALUES(@PaymentNumber, @IsPayed, @OrderId)";
                conn.Open();
                conn.Execute(sQuery, item );
            }
        }

        public void Update(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Payments SET PaymentNumber = @PaymentNumber, " +
                    "IsPayed = @IsPayed, OrderId = @OrderId WHERE ID = @Id";
                conn.Open();
                conn.Execute(sQuery, item );
            }
        }

        public void Delete(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Currencies WHERE ID = @id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public IEnumerable<Payment> FindByOrder(Func<Payment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Payment Get(Payment item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Payments WHERE ID = @id";
                conn.Open();
                return conn.Query<Payment>(sQuery, item).FirstOrDefault();
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Payments";
                conn.Open();
                return conn.Query<Payment>(sQuery);
            }
        }
    }
}
