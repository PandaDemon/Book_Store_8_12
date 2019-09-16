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
        //private readonly IOrder _order;
        private readonly IMapper _mapper;

        //public OrderService(IOrder order, IMapper mapper)
        //{
        //    _order = order;
        //    _mapper = mapper;
        //}
        public void Create(PrintingOrderModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingOrderModel> GetAll(string order)
        {
            throw new NotImplementedException();
        }

        public PrintingOrderModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingOrderModel> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationOrder(PrintingOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
