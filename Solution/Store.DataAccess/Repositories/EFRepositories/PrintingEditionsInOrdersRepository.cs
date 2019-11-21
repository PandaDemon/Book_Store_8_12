using Microsoft.EntityFrameworkCore;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionsInOrdersRepository : BaseEFRepository<PrintingEditionsInOrders>, IPrintingEditionsInOrdersRepository
    {
        public PrintingEditionsInOrdersRepository(DataBaseContext context) : base(context)
        {
        }

        public void AddPrintingEditionInOrders(IEnumerable<PrintingEditionsInOrders> items)
        {
            Context.PrintingEditionsInOrders.AddRange(items);
            Context.SaveChanges();
        }

        public IEnumerable<PrintingEditionsInOrders> FilterByOrderStatus(bool value)
        {
            IEnumerable<PrintingEditionsInOrders> result = Context.PrintingEditionsInOrders
                 .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.ApplicationUser)
                 .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
                 .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.Payment)
                 .Where(printInOrders => printInOrders.Order.Payment.IsPayed == value);

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> GetAllWithInclude()
        {
            IEnumerable<PrintingEditionsInOrders> result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency);

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> GetOrdersByUserId(string id)
        {
            IEnumerable<PrintingEditionsInOrders> result = Context.PrintingEditionsInOrders
               .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.Payment)
               .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.ApplicationUser)
               .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
               .Where(printInOrders => printInOrders.Order.ApplicationUserId == id);

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> GetPrintingEdtionForOrder(int orderId)
        {
            IEnumerable<PrintingEditionsInOrders> result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(order => order.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
                .Where(printInOrders => printInOrders.OrderId == orderId);

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> OrderNumberSort(SortOrder order)
        {
            IEnumerable<PrintingEditionsInOrders> result = new List<PrintingEditionsInOrders>();

            if (order == SortOrder.Ascending)
            {
                result = Context.PrintingEditionsInOrders
               .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.Payment)
               .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.ApplicationUser)
               .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
               .OrderBy(printInOrders => printInOrders.Order.Id);
            }

            if (order == SortOrder.Descending)
            {
                result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
                .OrderByDescending(printInOrders => printInOrders.Order.Id);
            }

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> OrderTimeSort(SortOrder order)
        {
            IEnumerable<PrintingEditionsInOrders> result = new List<PrintingEditionsInOrders>();

            if (order == SortOrder.Ascending)
            {
                result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
                .OrderBy(printInOrders => printInOrders.Order.DatePurchase);
            }

            if (order == SortOrder.Descending)
            {
                result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency)
                .OrderByDescending(printInOrders => printInOrders.Order.DatePurchase);
            }

            return result;
        }

        public IEnumerable<PrintingEditionsInOrders> SortData(SortOrder sortOrder, string sortedElement)
        {
            IEnumerable<PrintingEditionsInOrders> result = new List<PrintingEditionsInOrders>();

            result = Context.PrintingEditionsInOrders
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.Payment)
                .Include(printInOrders => printInOrders.Order).ThenInclude(ord => ord.ApplicationUser)
                .Include(printInOrders => printInOrders.PrintingEdition).ThenInclude(print => print.Currency);

            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(sortedElement, parameter);

            if (property != null)
            {
                Func<PrintingEditionsInOrders, dynamic> sortBy = Expression.Lambda<Func<PrintingEditionsInOrders, dynamic>>
                    (Expression.TypeAs(property, typeof(object)), parameter).Compile();
                result = sortOrder == SortOrder.Ascending ? result.OrderBy(sortBy) : result.OrderByDescending(sortBy);
            }

            return result;
        }

        private Expression GetProperty(string element, Expression expression)
        {
            if (element == "none")
            {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(element))
            {
                var splitedArray = element.Split('.');
                MemberExpression memberExpretion = Expression.Property(expression, splitedArray.First());
                var lengthOfArray = splitedArray.Length;
                var lengthOfFirstElement = splitedArray.First().Length;

                return lengthOfArray > 1 ? GetProperty(element.Remove(0, lengthOfFirstElement + 1), memberExpretion) : memberExpretion;
            }

            return null;
        }
    }
}
