using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class OrderDapperRepository : IOrderRepository
    {
        private readonly IConfiguration _config;

        public OrderDapperRepository(IConfiguration config)
        {
            _config = config;
        }
        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public void Create(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"INSERT INTO Orders (DatePurchase, Description, Quantity, UserId) VALUES(@DatePurchase, @Description, @Quantity, @UserId)";

                conn.Execute(sQuery, item);
            }
        }

        public void Update(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"UPDATE Orders SET DatePurchase = @DatePurchase, 
                    Description = @Description, Quantity = @Quantity, UserId = @UserId WHERE Id = @Id";

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

        public Order Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Orders WHERE ID = @id";

                return conn.Query<Order>(sQuery, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Orders";

                return conn.Query<Order>(sQuery);
            }
        }
    }
}
