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
    public class PrintingEditionDapperRepository : IPrintingEditionRepository
    {
        private readonly IConfiguration _config;

        public PrintingEditionDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public void Create(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"INSERT INTO PrintingEditions (Description, Status, Type, NameEdition, AvatarUrl, Price, CurrencyId) VALUES
                    (@Description, @Status, @Type, @NameEdition, @AvatarUrl, @Price, @CurrencyId)";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Update(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"UPDATE PrintingEditions SET Description = @Description, Status = @Status, Type = @Type,
                     NameEdition = @NameEdition, AvatarUrl = @AvatarUrl, Price = @Price, CurrencyId = @CurrencyId,
                     WHERE ID = @Id";

                conn.Execute(sQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM PrintingEditions WHERE ID = @id";

                conn.Execute(sQuery, id);
            }
        }


        public IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions WHERE CATEGORYID = @CategotyId and BETWEEN @min AND @max and FilterName = @Name";

                return conn.Query<PrintingEdition>(sQuery, new { CategotyId = categotyId, min = 1, max = 2, Name = string.Empty});
            }
        }


        public PrintingEdition Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions WHERE ID = @id";

                return conn.Query<PrintingEdition>(sQuery, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<PrintingEdition> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions";

                return conn.Query<PrintingEdition>(sQuery);
            }
        }

        public IEnumerable<PrintingEdition> SortByPrice(Enum sortValue)
        {
            using (IDbConnection conn = Connection)
            {
                string value;
                
                if (sortValue.Equals(0))
                {
                    value = "ASC";
                }
                else
                {
                    value = "DESC";
                }

                string sQuery = $"SELECT * FROM PrintingEditions ORDER BY Sales {value}";

                return conn.Query<PrintingEdition>(sQuery);
            }
        }
    }
}
