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
    public class PrintingEditionDapperRepository : IPrintingEditionRepository
    {
        private readonly IConfiguration _config;

        public PrintingEditionDapperRepository(IConfiguration config)
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
        public void Create(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO PrintingEditions (Description, Status, Type, NameEdition, AvatarUrl, Price, CurrencyId) VALUES" +
                    "(@Description, @Status, @Type, @NameEdition, @AvatarUrl, @Price, @CurrencyId)";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Update(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE PrintingEditions SET Description = @Description, Status = @Status, Type = @Type, " +
                     "NameEdition = @NameEdition, Image = @Image, Price = @Price, CurrencyId = @CurrencyId, " +
                     "WHERE ID = @Id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Delete(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM PrintingEditions WHERE ID = @id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }


        // todo
        public IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "";
                conn.Open();
                return conn.Query<PrintingEdition>(sQuery);
            }
        }
        //ToDO!!!!


        public PrintingEdition Get(PrintingEdition item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions WHERE ID = @id";
                conn.Open();
                return conn.Query<PrintingEdition>(sQuery, item).FirstOrDefault();
            }
        }

        public IEnumerable<PrintingEdition> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions";
                conn.Open();
                return conn.Query<PrintingEdition>(sQuery);
            }
        }

        public IEnumerable<PrintingEdition> SortByPrice(string sortValue)
        {
            using (IDbConnection conn = Connection)
            {
                
                if (sortValue == "high")
                {
                    string sQuery = "SELECT * FROM PrintingEditions ORDER BY Sales ASC";
                    conn.Open();
                    return conn.Query<PrintingEdition>(sQuery);
                }
                else
                {
                    string sQuery = "SELECT * FROM PrintingEditions ORDER BY Sales DESC";
                    conn.Open();
                    return conn.Query<PrintingEdition>(sQuery);
                }
                
            }
        }
    }
}
