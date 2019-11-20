using AutoMapper;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order = PrintStore.DataAccess.Entities.Order;

namespace PrintStore.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPrintingEditionRepository _printEditRepository;
        private readonly IPrintingEditionsInOrdersRepository _printEditInOrdersRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository,
            IMapper mapper,
            IPrintingEditionRepository printEditRepository,
            IPaymentRepository paymentRepository,
            IPrintingEditionsInOrdersRepository printEditInOrdersRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _printEditRepository = printEditRepository;
            _printEditInOrdersRepository = printEditInOrdersRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(OrderViewModel model)
        {
            Order order = _mapper.Map<Order>(model);
            var printingEditions = new List<PrintingEdition>();
            var printEditionsInOrders = new List<PrintingEditionsInOrders>();

            order.DatePurchase = DateTime.UtcNow;

            await _orderRepository.Create(order);            

            foreach (AuthorsInPrintingEditionsViewModel printEd in model.Products)
            {
                printingEditions.Add(await _printEditRepository.Get(printEd.PrtintingEditionId));
            }                      

            foreach (PrintingEdition print in printingEditions)
            {
                printEditionsInOrders.Add(new PrintingEditionsInOrders
                {
                    PrintingEditionId = print.Id,
                    OrderId = order.Id,
                    OrderAmount = model.OrderAmount,
                    PrintEditionQuantity = model.Products.Find(x => x.PrtintingEditionId == print.Id).PrintinEditionQuantityForOrder
                });
            }

            _printEditInOrdersRepository.AddPrintingEditionInOrders(printEditionsInOrders);

            return order.Id;
        }

        public async Task CreatePayment(PaymentViewModel model)
        {
            Payment payment = _mapper.Map<Payment>(model);

            await _paymentRepository.Create(payment);
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders(string order)
        {
            IEnumerable<Order> orders = await _orderRepository.GetAll();
            var models = new List<OrderViewModel>();

            foreach (Order ord in orders)
            {
                OrderViewModel model = _mapper.Map<OrderViewModel>(ord);
                models.Add(model);
            }

            return models;
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            Order order = await _orderRepository.Get(id);
            var model = _mapper.Map<OrderViewModel>(order);

            return model;
        }

        public IEnumerable<UserOrdersViewModel> GetOrdersByUserId(string id)
        {
            IEnumerable<PrintingEditionsInOrders> printingEditionInOrders = _printEditInOrdersRepository.GetOrdersByUserId(id);
            var modelsList = new List<UserOrdersViewModel>();

            foreach (PrintingEditionsInOrders printEd in printingEditionInOrders)
            {
                UserOrdersViewModel orderModel = modelsList.FirstOrDefault(order => order.OrderId == printEd.OrderId);

                if (orderModel == null)
                {
                    orderModel = new UserOrdersViewModel
                    {
                        OrderId = printEd.OrderId,
                        OrderAmount = printEd.OrderAmount,
                        OrderStatus = printEd.Order.Payment.IsPayed,
                        DateTime = printEd.Order.DatePurchase,
                        PrintEditionQuantity = printEd.PrintEditionQuantity
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

        public async Task UpdateInformationAboutOrder(OrderViewModel model)
        {
            Order orderData = await _orderRepository.Get(model.Id);

            if (orderData != null)
            {
                orderData = _mapper.Map<Order>(model);

                await _orderRepository.Update(orderData);
            }
        }
    }
}
