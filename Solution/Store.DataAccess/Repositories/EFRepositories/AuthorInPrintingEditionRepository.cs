using Microsoft.EntityFrameworkCore;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorInPrintingEditionRepository : BaseEFRepository<AuthorInPrintingEditions>, IAuthorInPrintingEditionRepository
    {
        private readonly string _printStatusColumn = "PrintingEdition.Status";
        private readonly string _printTypeColumn = "PrintingEdition.Type";

        public AuthorInPrintingEditionRepository(DataBaseContext context) : base(context)
        {
        }
           
        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int id)
        {
            IEnumerable<AuthorInPrintingEditions> authors = Context.AuthorInPrintingEditions
                .Include(author => author.Author)
                .Include(print => print.PrintingEdition)
                .Where(authInPe => authInPe.AuthorId == id);

            return authors;
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEditionID(int id)
        {
            IEnumerable<AuthorInPrintingEditions> authors = Context.AuthorInPrintingEditions
                .Include(authInPe => authInPe.Author)
                .Include(authInPe => authInPe.PrintingEdition)
                .ThenInclude(printEd => printEd.Currency)
                .Where(authInPe => authInPe.PrintingEditionId == id);

            return authors;
        }

        public IEnumerable<AuthorInPrintingEditions> GetWithInclude()
        {
            IEnumerable<AuthorInPrintingEditions> authorInPrintingEditions = Context.AuthorInPrintingEditions
                .Include(authInPe => authInPe.Author)
                .Include(authInPe => authInPe.PrintingEdition)
                .ThenInclude(printEd => printEd.Currency);

            return authorInPrintingEditions;
        }

        public void DeleteAuthorInPe(IEnumerable<AuthorInPrintingEditions> items)
        {
            List<AuthorInPrintingEditions> authorInPrintingEditions = new List<AuthorInPrintingEditions>();

            foreach (AuthorInPrintingEditions authorInPe in items)
            {
                authorInPrintingEditions.Add(Context.AuthorInPrintingEditions.Find(authorInPe.AuthorId, authorInPe.PrintingEditionId));
            }

            Context.RemoveRange(authorInPrintingEditions);
            Context.SaveChanges();
        }

        public void AddAuthorInPe(IEnumerable<AuthorInPrintingEditions> items)
        {
            Context.AuthorInPrintingEditions.AddRange(items);
            Context.SaveChanges();
        }

        public IEnumerable<AuthorInPrintingEditions> SortPriceInRange(int sortPriceFrom, int sortPriceTo, int firstElement, int lastElement)
        {
            IEnumerable<AuthorInPrintingEditions> dataset = Context.AuthorInPrintingEditions
              .Include(authInPe => authInPe.Author)
              .Include(authInPe => authInPe.PrintingEdition)
              .ThenInclude(printEd => printEd.Currency)
              .Where(authInPe => authInPe.PrintingEdition.Price < sortPriceTo && authInPe.PrintingEdition.Price > sortPriceFrom)
              .Skip(firstElement)
              .Take(lastElement);

            return dataset;
        }

        public IEnumerable<AuthorInPrintingEditions> GetAuthorsInPrintingEditionsPage(int firstElement, int lastElement)
        {
            IEnumerable<AuthorInPrintingEditions> authorInPrintingEditions = Context.AuthorInPrintingEditions
                .Include(authInPe => authInPe.Author)
                .Include(authInPe => authInPe.PrintingEdition)
                .ThenInclude(printEd => printEd.Currency)
                .Skip(firstElement)
                .Take(lastElement);

            return authorInPrintingEditions;
        }

        public async Task<int> GetCountOfEditionsInStoreAsync()
        {
            int count = await Context.AuthorInPrintingEditions.CountAsync();
            return count;
        }        

        public IEnumerable<AuthorInPrintingEditions> SortAndFilterData(SortOrder sortOrder, string sortedElement, int firstElement, int lastElement,
            string filter, PrintingEditionType type, PrintingEditionStatus status)
        {           
            IQueryable<AuthorInPrintingEditions> result = Context.AuthorInPrintingEditions
                   .Include(authInPe => authInPe.Author)
                   .Include(authInPe => authInPe.PrintingEdition)
                   .ThenInclude(printEd => printEd.Currency);

            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(sortedElement, parameter);
            Func<AuthorInPrintingEditions, dynamic> sortBy = null;

            IEnumerable<AuthorInPrintingEditions> authorInPrintingEditions = new List<AuthorInPrintingEditions>();

            if (property!= null)
            {
                sortBy = Expression.Lambda<Func<AuthorInPrintingEditions, dynamic>>(Expression.TypeAs(property, typeof(object)), parameter).Compile();
            }            

            var filterExpression = MakefilterExpression(sortedElement, filter, type, status);

            if (filterExpression!=null && sortOrder == SortOrder.Ascending)
            {
                authorInPrintingEditions = result.AsEnumerable().Where(filterExpression).OrderBy(sortBy).AsEnumerable()
                    .Skip(firstElement).Take(lastElement - firstElement);                
            }

            if (filterExpression != null && sortOrder == SortOrder.Descending)
            {
                authorInPrintingEditions = result.AsEnumerable().Where(filterExpression).OrderByDescending(sortBy)
                    .Skip(firstElement).Take(lastElement - firstElement);
            }

            if (filterExpression == null && property != null)
            {
                authorInPrintingEditions = (sortOrder == SortOrder.Ascending ? result.OrderBy(sortBy) : result.OrderByDescending(sortBy)).AsQueryable()
                    .Skip(firstElement).Take(lastElement - firstElement);
                result.AsEnumerable();
            }

            if (property == null)
            {
                authorInPrintingEditions = result.AsEnumerable().Skip(firstElement).Take(lastElement - firstElement);
            }     

            return authorInPrintingEditions;
        }        

        public IEnumerable<AuthorInPrintingEditions> FilterData(string filter, string sortedElement, int firstElement, int lastElement)
        {

            IQueryable<AuthorInPrintingEditions> result = Context.AuthorInPrintingEditions
                   .Include(authInPe => authInPe.Author)
                   .Include(authInPe => authInPe.PrintingEdition)
                   .ThenInclude(printEd => printEd.Currency);

            var splitedArray = sortedElement.Split('.');

            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(sortedElement, parameter);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            var someValue = Expression.Constant(filter, typeof(string));
            var containsMethodExp = Expression.Call(property, method, someValue);

            Func<AuthorInPrintingEditions, bool> filterExpression = Expression.Lambda<Func<AuthorInPrintingEditions, bool>>(containsMethodExp, parameter).Compile();

            IEnumerable<AuthorInPrintingEditions> authorInPrintingEditions =
                result.Where(filterExpression).Skip(firstElement).Take(lastElement - firstElement);

            return authorInPrintingEditions;
        }

        private Func<AuthorInPrintingEditions, bool> MakefilterExpression(string sortedElement, string filter, PrintingEditionType type, PrintingEditionStatus status)
        {
            Expression body = null;
            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));

            if (filter != "none")
            {
                Expression property = GetProperty(sortedElement, parameter);
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var someValue = Expression.Constant(filter, typeof(string));
                body = Expression.Call(property, method, someValue);
            }

            if (type != PrintingEditionType.None)
            {
                Expression property = GetProperty(_printTypeColumn, parameter);
                var someValue = Expression.Constant(type, typeof(PrintingEditionType));
                BinaryExpression containsMethodExpForType = Expression.Equal(property, someValue);
                
                if (body != null)
                {
                    body = Expression.And(body, containsMethodExpForType);
                
                }

                if (body == null)
                {
                    body = containsMethodExpForType;
                }         
            }

            if (status != PrintingEditionStatus.None && status != PrintingEditionStatus.NotAvailable)
            {
                Expression property = GetProperty(_printStatusColumn, parameter);
                var someValue = Expression.Constant(status, typeof(PrintingEditionStatus));
                BinaryExpression containsMethodExpForStatus = Expression.Equal(property, someValue);
                
                if (body != null)
                {
                    body = Expression.And(body, containsMethodExpForStatus);
                }

                if (body == null)
                {
                    body = containsMethodExpForStatus;
                }
            }

            if (status == PrintingEditionStatus.NotAvailable)
            {
                Expression property = GetProperty(_printStatusColumn, parameter);
                var someValue = Expression.Constant(status, typeof(PrintingEditionStatus));
                BinaryExpression containsMethodExpForStatus = Expression.NotEqual(property, someValue);

                if (body != null)
                {
                    body = Expression.And(body, containsMethodExpForStatus);
                }

                if (body == null)
                {
                    body = containsMethodExpForStatus;
                }
            }

            if(body == null)
            {
                return null;
            }

            Func<AuthorInPrintingEditions, bool> filterExpression = Expression.Lambda<Func<AuthorInPrintingEditions, bool>>(body, parameter).Compile();

            return filterExpression;
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
