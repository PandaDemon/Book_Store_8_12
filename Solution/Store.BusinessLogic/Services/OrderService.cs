using AutoMapper;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrder _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrder orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public void CreateOrder(PrintingOrderModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingOrderModel> GetAllOrders(string order)
        {
            throw new NotImplementedException();
        }

        public PrintingOrderModel GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingOrderModel> GetUserOrders(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationAboutOrder(PrintingOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
