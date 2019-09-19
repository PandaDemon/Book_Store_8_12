using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorDapperRepository : BaseDapperRepository<Author>, IAuthorRepository
    {
        public AuthorDapperRepository(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<Author> FilterByName(string firstName, string lastName)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors WHERE (FirstName LIKE '%' + @FIRSTNAME + '%') OR (LASTNAME LIKE '%' + @lastName + '%')";

                return conn.Query<Author>(sQuery, new { firstName, lastName });
            }
        }
    }
}
