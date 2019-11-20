using Dapper;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class PrintingEditionsInOrdersRepository : BaseDapperRepository<PrintingEditionsInOrders>, IPrintingEditionsInOrdersRepository
    {
        public PrintingEditionsInOrdersRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void AddPrintingEditionInOrders(IEnumerable<PrintingEditionsInOrders> items)
        {
            string sqlQuery = "INSERT INTO PrintingEditionsInOrders (OrderId, PrintingEditionId) VALUES(@OrderId, @PrintingEditionId)";

            using (IDbConnection db = Connection)
            {
                db.Execute(sqlQuery, items);
            }
        }

        public IEnumerable<PrintingEditionsInOrders> FilterByOrderStatus(bool value)
        {
            var query = $"SELECT * FROM PrintingEditionsInOrders " +
                 $"JOIN Orders ON PrintingEditionsInOrders.OrderId = Orders.Id " +
                 $"JOIN Payments ON Payments.OrderId = Orders.Id " +
                 $"JOIN PrintingEditions ON PrintingEditionsInOrders.PrintingEditionId = PrintingEditions.Id ";

            return GetResultList(query);
        }

        public IEnumerable<PrintingEditionsInOrders> GetAllWithInclude()
        {
            var query = $"SELECT O.ApplicationUserId, O.DatePurchase, O.Id, " +
                $"PeInO.OrderId, PeInO.OrderAmount, PeInO.PrintEditionQuantity, PeInO.PrintingEditionId, P.IsPayed, P.Id, " +                
                $"PE.NameEdition, PE.Type, PE.Id " +
                $"FROM PrintingEditionsInOrders PeInO " +
                $"JOIN Orders O ON PeInO.OrderId = O.Id " +                
                $"JOIN Payments P ON P.OrderId = O.Id  " +
                $"JOIN PrintingEditions PE ON PeInO.PrintingEditionId = PE.Id";

            return GetResultList(query);
        }

        public IEnumerable<PrintingEditionsInOrders> GetOrdersByUserId(string id)
        {
            var query = $"SELECT * FROM PrintingEditionsInOrders " +
                $"JOIN Orders ON PrintingEditionsInOrders.OrderId = Orders.Id " +
                $"JOIN Payments ON Payments.OrderId = Orders.Id " +
                $"JOIN PrintingEditions ON PrintingEditionsInOrders.PrintingEditionId = PrintingEditions.Id " +
                $"WHERE Orders.ApplicationUserId = {id}";

            return GetResultList(query);
        }
        
        public IEnumerable<PrintingEditionsInOrders> SortData(SortOrder sortOrder, string sortedElement)
        {
            string orderBy = "";
            string columnName = GetColumn(sortedElement);

            if (sortOrder == SortOrder.Ascending)
            {
                orderBy = $"ORDER BY {columnName} ASC";
            }
            if (sortOrder == SortOrder.Descending)
            {
                orderBy = $"ORDER BY {columnName} DESC";
            }
            if (sortOrder == SortOrder.Unspecified)
            {
                orderBy = " ";
            }

            var query = $"SELECT * FROM PrintingEditionsInOrders " +
                $"JOIN Orders ON PrintingEditionsInOrders.OrderId = Orders.Id " +
                $"JOIN Payments ON Payments.OrderId = Orders.Id " +
                $"JOIN PrintingEditions ON PrintingEditionsInOrders.PrintingEditionId = PrintingEditions.Id " +
                $"{orderBy}";

            return GetResultList(query);
        }

        private IEnumerable<PrintingEditionsInOrders> GetResultList(string query)
        {
            using (IDbConnection db = Connection)
            {
                var list = db.Query<PrintingEditionsInOrders, Order, Payment, PrintingEdition, PrintingEditionsInOrders>(
                    query,
                    (printEdInOrder, order, payment, print) =>
                    {
                        PrintingEditionsInOrders dataOrders;
                        dataOrders = printEdInOrder;
                        dataOrders.Order = order;
                        dataOrders.Order.Payment = payment;
                        dataOrders.PrintingEdition = print;
                        return dataOrders;
                    },
                    splitOn: "Id,Id,Id,Id");

                return list;
            };
        }

        private string GetColumn(string element)
        {
            if (element == "none")
            {
                return "Authors.Id";
            }
            if (!string.IsNullOrWhiteSpace(element))
            {
                var splitedArray = element.Split('.');
                var firstElement = $"{splitedArray.First()}s";
                var lengthOfFirstElement = firstElement.Length;
                var columnName = $"{firstElement}{element.Remove(0, lengthOfFirstElement - 1)}";

                return columnName;
            }

            return null;
        }
    }
}
