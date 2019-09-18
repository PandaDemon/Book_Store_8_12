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

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));


        public void Create(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Currencies (CurrencyName) VALUES(@CurrencyName)";

                conn.Execute(sQuery, item);
            }
        }

        public void Update(Currency item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Currencies SET CurrencyName = @CurrencyName WHERE ID = @Id";

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

        public Currency Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Currencies WHERE ID = @ID";

                return conn.Query<Currency>(sQuery, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Currencies";

                return conn.Query<Currency>(sQuery);
            }
        }
    }
}
