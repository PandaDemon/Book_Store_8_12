using Dapper;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class AuthorInPrintingEditionRepository : BaseDapperRepository<AuthorInPrintingEditions>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public void AddAuthorInPe(IEnumerable<AuthorInPrintingEditions> items)
        {
            using (IDbConnection db = Connection)
            {
                string sqlQuery = "INSERT INTO AuthorInPrintingEditions (AuthorId, PrintingEditionId) VALUES(@AuthorId, @PrintingEditionId)";
                db.ExecuteAsync(sqlQuery, items);
            }
        }

        public void DeleteAuthorInPe(IEnumerable<AuthorInPrintingEditions> items)
        {
            using (IDbConnection db = Connection)
            {
                string sqlQuery = $"DELETE FROM AuthorInPrintingEditions WHERE AuthorId = @AuthorId AND PrintingEditionId = @PrintingEditionId";
                db.Execute(sqlQuery, items);
            }
        }

        public IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionDescription(string filter, int firstElement, int lastElement)
        {
            var rows = lastElement - firstElement;
            var query = $"SELECT * FROM AuthorInPrintingEditions " +
                $"JOIN PrintingEditions ON PrintingEditions.Id = AuthorInPrintingEditions.PrintingEditionId " +
                $"JOIN Authors ON Authors.Id = AuthorInPrintingEditions.AuthorId " +
                $"JOIN Currencies on Currencies.Id = PrintingEditions.CurrencyId " +
                $"WHERE PrintingEditions.Description LIKE '%{filter}%' " +
                $"ORDER BY AuthorInPrintingEditions.AuthorId " +
                $"OFFSET {firstElement} ROWS FETCH NEXT {rows} ROWS ONLY";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int id)
        {
            var query = $"SELECT * FROM AuthorInPrintingEditions " +
                $"JOIN PrintingEditions ON PrintingEditions.Id = AuthorInPrintingEditions.PrintingEditionId " +
                $"JOIN Authors ON Authors.Id = AuthorInPrintingEditions.AuthorId " +
                $"JOIN Currencies on Currencies.Id = PrintingEditions.CurrencyId " +
                $"WHERE AuthorInPrintingEditions.AuthorId = {id} ";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEditionID(int id)
        {
            var query = $"SELECT * FROM AuthorInPrintingEditions AIPE " +
                $"JOIN PrintingEditions PE ON PE.Id = AIPE.PrintingEditionId " +
                $"JOIN Authors Au ON Au.Id = AIPE.AuthorId " +
                $"JOIN Currencies C on C.Id = PE.CurrencyId " +
                $"WHERE AIPE.PrintingEditionId = {id}";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> GetAuthorsInPrintingEditionsPage(int firstElement, int lastElement)
        {
            var rows = lastElement - firstElement;
            var query = $"SELECT * FROM AuthorInPrintingEditions AIPE " +
               $"JOIN PrintingEditions PE ON PE.Id = AIPE.PrintingEditionId " +
               $"JOIN Authors A ON A.Id = AIPE.AuthorId " +
               $"JOIN Currencies C on C.Id = PE.CurrencyId " +
               $"ORDER BY AIPE.AuthorId " +
               $"OFFSET {firstElement} ROWS FETCH NEXT {rows} ROWS ONLY";

            return GetResultList(query);
        }

        public async Task<int> GetCountOfEditionsInStoreAsync()
        {
            var query = "SELECT COUNT(*) FROM AuthorInPrintingEditions";

            using (IDbConnection db = Connection)
            {
                int count = await db.ExecuteScalarAsync<int>(query);
                return count;
            }
        }

        public IEnumerable<AuthorInPrintingEditions> GetWithInclude()
        {
            var query = $"SELECT * FROM AuthorInPrintingEditions AIPE " +
                $"JOIN PrintingEditions PE ON PE.Id = AIPE.PrintingEditionId " +
                $"JOIN Authors A ON A.Id = AIPE.AuthorId " +
                $"JOIN Currencies C on C.Id = PE.CurrencyId ";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> SortAndFilterData(SortOrder sortOrder, string column, int firstElement, int lastElement, 
            string filter, PrintingEditionType type, PrintingEditionStatus status)
        {
            var rows = lastElement - firstElement;
            string sort = "";

            if (sortOrder == SortOrder.Ascending)
            {
                sort = "ASC";
            }
            if (sortOrder == SortOrder.Descending)
            {
                sort = "DESC";
            }            

            string columnName = GetColumn(column);          

            string filterString = MakeFilterString(column, filter, type, status);

            var query = $"SELECT * FROM AuthorInPrintingEditions " +
                $"JOIN PrintingEditions ON PrintingEditions.Id = AuthorInPrintingEditions.PrintingEditionId " +
                $"JOIN Authors ON Authors.Id = AuthorInPrintingEditions.AuthorId " +
                $"JOIN Currencies on Currencies.Id = PrintingEditions.CurrencyId " +
                $"{filterString}" +
                $"ORDER BY {columnName} {sort} " +
                $"OFFSET {firstElement} ROWS FETCH NEXT {rows} ROWS ONLY";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> SortPriceInRange(int sortPriceFrom, int sortPriceTo, int firstElement, int lastElement)
        {
            var rows = lastElement - firstElement;
            var query = $"SELECT * FROM AuthorInPrintingEditions AIPE " +
                $"JOIN PrintingEditions PE ON PE.Id = AIPE.PrintingEditionId " +
                $"JOIN Authors A ON A.Id = AIPE.AuthorId " +
                $"JOIN Currencies C on C.Id = PE.CurrencyId " +
                $"where PE.Price > {sortPriceFrom} and PE.Price < {sortPriceTo} " +
                $"ORDER BY AIPE.AuthorId " +
                $"OFFSET {firstElement} ROWS FETCH NEXT {rows} ROWS ONLY";

            return GetResultList(query);
        }

        public IEnumerable<AuthorInPrintingEditions> FilterData(string filter, string column, int firstElement, int lastElement)
        {
            var rows = lastElement - firstElement;
            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(column, parameter);
            string columnName = " ";
            string where = " ";

            if (property != null)
            {
                columnName = GetColumn(column);
                where = $"WHERE {columnName} LIKE '%{filter}%'";
            }    
            
            var query = $"SELECT * FROM AuthorInPrintingEditions " +
                $"JOIN PrintingEditions ON PrintingEditions.Id = AuthorInPrintingEditions.PrintingEditionId " +
                $"JOIN Authors ON Authors.Id = AuthorInPrintingEditions.AuthorId " +
                $"JOIN Currencies on Currencies.Id = PrintingEditions.CurrencyId " +
                $"{where} " +
                $"ORDER BY AuthorInPrintingEditions.AuthorId " +
                $"OFFSET {firstElement} ROWS FETCH NEXT {rows} ROWS ONLY";

            return GetResultList(query);
        }

        private string MakeFilterString(string column, string filter, PrintingEditionType type, PrintingEditionStatus status)
        {
            string columnName = GetColumn(column);
            string result = null;

            if(filter != "none")
            {
                result = $"WHERE {columnName} LIKE '%{filter}%'";
            }

            if (type != PrintingEditionType.None)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result = $"{result} AND PrintingEditions.Type = '{(int)type}' ";
                }

                if (String.IsNullOrEmpty(result))
                {
                    result = $"WHERE PrintingEditions.Type = '{(int)type}' ";
                }

            }

            if (status != PrintingEditionStatus.None && status != PrintingEditionStatus.NotAvailable)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result = $"{result} AND PrintingEditions.Status = '{(int)status}' ";
                }

                if (String.IsNullOrEmpty(result))
                {
                    result = $"WHERE PrintingEditions.Status = '{(int)status}' ";
                }
            }

            if (status == PrintingEditionStatus.NotAvailable)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    result = $"{result} AND PrintingEditions.Status <> '{(int)status}' ";
                }

                if (String.IsNullOrEmpty(result))
                {
                    result = $"WHERE PrintingEditions.Status <> '{(int)status}' ";
                }
            }

            return result;
        }
        private IEnumerable<AuthorInPrintingEditions> GetResultList(string query)
        {
            using (IDbConnection db = Connection)
            {
                var list = db.Query<AuthorInPrintingEditions, PrintingEdition, Author, Currency, AuthorInPrintingEditions>(
                    query,
                    (authorInPE, printEd, author, currency) =>
                    {
                        AuthorInPrintingEditions authorInPeData;
                        authorInPeData = authorInPE;
                        authorInPeData.Author = author;
                        authorInPeData.PrintingEdition = printEd;
                        authorInPeData.PrintingEdition.Currency = currency;

                        return authorInPeData;
                    },
                    splitOn: "Id,Id,Id");
                return list;
            };
        }

        private string GetColumn(string element)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(AuthorInPrintingEditions));
            Expression property = GetProperty(element, parameter);

            if (element == "none" && property==null)
            {
                return "Authors.Id";
            }
            if (!string.IsNullOrWhiteSpace(element))
            {
                var splitedArray = element.Split('.');
                var firstElement = $"{splitedArray.First()}s";
                var lengthOfFirstElement = firstElement.Length;
                var columnName = $"{firstElement}{element.Remove(0, lengthOfFirstElement-1)}";

                return columnName;
            }

            return null;
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
