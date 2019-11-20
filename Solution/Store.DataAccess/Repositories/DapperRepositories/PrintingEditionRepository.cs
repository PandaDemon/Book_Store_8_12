using Dapper;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class PrintingEditionRepository : BaseDapperRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public IEnumerable<PrintingEdition> SortPrintEdidtionsByPrice(SortOrder sortOrder)
        {
            string query = "";

            if (sortOrder == SortOrder.Ascending)
            {
                query = $"SELECT * FROM PrintingEditions ORDER BY Price ASC";
            }
            if (sortOrder == SortOrder.Descending)
            {
                query = $"SELECT * FROM PrintingEditions ORDER BY Price DESC";
            }
            if (sortOrder == SortOrder.Unspecified)
            {
                query = $"SELECT * FROM PrintingEditions";
            }

            using (IDbConnection db = Connection)
            {
                return db.Query<PrintingEdition>(query);
            }
        }

        public IEnumerable<PrintingEdition> FilterByType(PrintingEditionType printingEditionType)
        {
            var type = (int)printingEditionType;

            using (IDbConnection db = Connection)
            {
                return db.Query<PrintingEdition>($"SELECT * FROM PrintingEditions WHERE Type = {type}");
            }
        }

        public IEnumerable<PrintingEdition> FilterTitle(string filter)
        {
            using (IDbConnection db = Connection)
            {
                string query = $"SELECT * FROM PrintingEditions WHERE NameEdition LIKE '%{filter}%'";
                return db.Query<PrintingEdition>(query);
            }
        }

        public IEnumerable<PrintingEdition> FilterPrintEdidtionsByPriceAnfType(PrintingEditionType printingEditionType, int minPrice, int maxPrice)
        {
            var type = (int)printingEditionType;

            using (IDbConnection db = Connection)
            {
                return db.Query<PrintingEdition>($"SELECT * FROM PrintingEditions WHERE Type = {type} AND Price BETWEEN {minPrice} AND  {maxPrice}");
            }
        }
    }
}
