using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        void Delete(int id);
        void Create(PrintingOrderModel model);
        void Update(PrintingOrderModel model);
        PrintingOrderModel Get(int id);
        IEnumerable<PrintingOrderModel> GetAll();
        IEnumerable<PrintingOrderModel> GetUser(int id);
        IEnumerable<PrintingOrderModel> GetPrintingEdition(int id);
    }
}
