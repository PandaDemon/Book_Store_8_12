using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        PrintingOrderModel GetOrderById(int id);
        void DeleteOrder(int id);
        void CreateOrder(PrintingOrderModel model);
        void UpdateInformationAboutOrder(PrintingOrderModel model);
        IEnumerable<PrintingOrderModel> GetUserOrders(int id);
        IEnumerable<PrintingOrderModel> GetAllOrders(string order);

    }
}
