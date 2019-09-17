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

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void Create(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Orders (DatePurchase, Description, Quantity, UserId) " +
                    "VALUES(@DatePurchase, @Description, @Quantity, @UserId)";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Update(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Orders SET DatePurchase = @DatePurchase, " +
                    "Description = @Description, Quantity = @Quantity, UserId = @UserId WHERE Id = @Id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Delete(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Currencies WHERE ID = @id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public IEnumerable<Order> FindByUser(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Order Get(Order item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Orders WHERE ID = @id";
                conn.Open();
                return conn.Query<Order>(sQuery, item).FirstOrDefault();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Orders";
                conn.Open();
                return conn.Query<Order>(sQuery);
            }
        }
    }
}
