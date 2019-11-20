using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PrintStore.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IPrintingEditionsInOrdersRepository _printingEditionOrdersRepository;

        public AdminService(IPrintingEditionsInOrdersRepository printingEditionOrdersRepository)
        {
            _printingEditionOrdersRepository = printingEditionOrdersRepository;
        }

        public IEnumerable<AdminManagmentViewModel> GetAllUsersOrder()
        {
            IEnumerable<PrintingEditionsInOrders> printingEditionInOrders = _printingEditionOrdersRepository.GetAllWithInclude();
            IEnumerable<AdminManagmentViewModel> modelsList = AdminManagmentViewModelForming(printingEditionInOrders);

            return modelsList;
        }

        public IEnumerable<AdminManagmentViewModel> OrderSort(SortOrder order, string sortedColumn)
        {
            IEnumerable<PrintingEditionsInOrders> printingEditionInOrders = _printingEditionOrdersRepository.SortData(order, sortedColumn);
            IEnumerable<AdminManagmentViewModel> modelsList = AdminManagmentViewModelForming(printingEditionInOrders);

            return modelsList;
        }

        public IEnumerable<AdminManagmentViewModel> FilterByOrderStatus(bool value)
        {
            IEnumerable<PrintingEditionsInOrders> printingEditionInOrders = _printingEditionOrdersRepository.FilterByOrderStatus(value);
            IEnumerable<AdminManagmentViewModel> modelsList = AdminManagmentViewModelForming(printingEditionInOrders);

            return modelsList;
        }

        private IEnumerable<AdminManagmentViewModel> AdminManagmentViewModelForming(IEnumerable<PrintingEditionsInOrders> printingEditionInOrders)
        {
            List<AdminManagmentViewModel> modelsList = new List<AdminManagmentViewModel>();

            IEnumerable<string> usersIdList = printingEditionInOrders.Select(x => x.Order.ApplicationUserId);

            foreach (PrintingEditionsInOrders printEd in printingEditionInOrders)
            {
                AdminManagmentViewModel orderModel = modelsList.FirstOrDefault(order => order.OrderId == printEd.OrderId);

                if (orderModel == null)
                {
                    orderModel = new AdminManagmentViewModel
                    {
                        Email = printEd.Order.ApplicationUser.Email,
                        UserName = $"{printEd.Order.ApplicationUser.FirstName} {printEd.Order.ApplicationUser.LastName}",
                        OrderId = printEd.OrderId,
                        OrderAmount = printEd.OrderAmount,
                        OrderStatus = printEd.Order.Payment.IsPayed,
                        DateTime = printEd.Order.DatePurchase
                    };

                    modelsList.Add(orderModel);
                }

                orderModel.Products.Add(new PrintingEditionViewModel
                {
                    NameEdition = printEd.PrintingEdition.NameEdition,
                    Type = printEd.PrintingEdition.Type
                });
            }

            return modelsList;
        }
    }
}
