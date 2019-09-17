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
    public class CurrencyDapperRepository : ICurrencyRepository
    {
        private readonly IConfiguration _config;

        public CurrencyDapperRepository(IConfiguration config)
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
        public void Create(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Currencies (CurrencyName) VALUES(@CurrencyName)";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Update(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Currencies SET CurrencyName = @CurrencyName WHERE ID = @Id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Delete(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Currencies WHERE ID = @id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public Currency Get(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Currencies WHERE ID = @ID";
                conn.Open();
                return conn.Query<Currency>(sQuery, item).FirstOrDefault();
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Currencies";
                conn.Open();
                return conn.Query<Currency>(sQuery);
            }
        }
    }
}
