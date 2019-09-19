using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using static Store.DataAccess.Entities.EntityEnum;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class PrintingEditionDapperRepository : BaseDapperRepository<PrintingEdition>, IPrintingEditionRepository
    {

        public PrintingEditionDapperRepository(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM PrintingEditions WHERE CATEGORYID = @CategotyId and @Price BETWEEN @min AND @max and FilterName = @Name";

                return conn.Query<PrintingEdition>(sQuery, new { CategotyId = categotyId, min = 1, max = 2, Name = string.Empty});
            }
        }

        public IEnumerable<PrintingEdition> SortByPrice(EntityEnum sortValue)
        {
            string value = "";

            if (sortValue == Asc)
            {
                value = "ASC";
            }

            if (sortValue == Desc)
            {
                value = "DESC";
            }

            using (IDbConnection conn = Connection)
            {
                string sQuery = $"SELECT * FROM PrintingEditions ORDER BY Sales {value}";

                return conn.Query<PrintingEdition>(sQuery);
            }
        }
    }
}
