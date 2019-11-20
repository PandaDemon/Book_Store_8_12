using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel> GetOrderById(int id);
        Task DeleteOrder(int id);
        Task<int> CreateOrder(OrderViewModel model);
        Task UpdateInformationAboutOrder(OrderViewModel model);
        Task<IEnumerable<OrderViewModel>> GetAllOrders(string order);
        Task CreatePayment(PaymentViewModel model);
        IEnumerable<UserOrdersViewModel> GetOrdersByUserId(string id);
    }
}
