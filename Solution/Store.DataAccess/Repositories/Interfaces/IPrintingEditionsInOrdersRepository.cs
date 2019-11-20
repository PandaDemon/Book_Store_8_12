using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionsInOrdersRepository: IBaseRepository<PrintingEditionsInOrders>
    {
        IEnumerable<PrintingEditionsInOrders> GetAllWithInclude();
        void AddPrintingEditionInOrders(IEnumerable<PrintingEditionsInOrders> items);
        IEnumerable<PrintingEditionsInOrders> SortData(SortOrder sortOrder, string sortedElement);
        IEnumerable<PrintingEditionsInOrders> FilterByOrderStatus(bool value);
        IEnumerable<PrintingEditionsInOrders> GetOrdersByUserId(string id);
    }
}
