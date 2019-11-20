using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Base;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(StoreDBContext context) : base(context)
        {
        }


        public IEnumerable<Author> SortByName(SortOrder sortOrder, string sortedElement)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(sortedElement, parameter);

            if (property != null)
            {
                Func<Author, dynamic> sortBy = Expression.Lambda<Func<Author, dynamic>>
                    (Expression.TypeAs(property, typeof(object)), parameter).Compile();

                IQueryable<Author> result = Context.Authors;
                var authors = sortOrder == SortOrder.Ascending ? result.OrderBy(sortBy).AsEnumerable() : result.OrderByDescending(sortBy).AsEnumerable();

                return authors;
            }

            return Context.Authors;
        }

        public IEnumerable<Author> FilterAuthors(string filter)
        {
            return Context.Authors.Where(author => author.FirstName.Contains(filter) || author.LastName.Contains(filter));
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
