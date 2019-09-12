using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        PrintingOrderModel GetById(int id);
        void Delete(int id);
        void Create(PrintingOrderModel model);
        void UpdateInformationOrder(PrintingOrderModel model);
        IEnumerable<PrintingOrderModel> GetUser(int id);
        IEnumerable<PrintingOrderModel> GetAll(string order);
    }
}
