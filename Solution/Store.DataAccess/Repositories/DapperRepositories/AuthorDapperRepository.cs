using Dapper;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.ConnectionStringProvider;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PrintStore.DataAccess.Repositories.DapperRepositories
{
    public class AuthorDapperRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        public AuthorDapperRepository(IConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        public IEnumerable<Author> FilterAuthors(string filter)
        {
            using (IDbConnection db = Connection)
            {
                string query = $"SELECT * FROM Authors WHERE FirstName LIKE '%{filter}%' OR LastName LIKE '%{filter}%'";
                return db.Query<Author>(query);
            }
        }

        public IEnumerable<Author> SortByName(SortOrder sortOrder, string sortedElement)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Author));
            MemberExpression memberExpretion = Expression.Property(parameter, sortedElement);
            
            if(memberExpretion == null)
            {
                using (IDbConnection db = Connection)
                {
                    return db.Query<Author>("SELECT * FROM Authors");
                }
            }

            string query = "";

            if (sortOrder == SortOrder.Ascending)
            {
                query = $"SELECT * FROM Authors ORDER BY {sortedElement} ASC";
            }

            if (sortOrder == SortOrder.Descending)
            {
                query = $"SELECT * FROM Authors ORDER BY {sortedElement} DESC";
            }

            if (sortOrder == SortOrder.Unspecified)
            {
                query = $"SELECT * FROM Authors";
            }

            using (IDbConnection db = Connection)
            {
                return db.Query<Author>(query);
            }
        }
    }
}
