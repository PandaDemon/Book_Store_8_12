using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class CategoryDapperRepository : BaseDapperRepository<Category>, ICategoryRepository
    {

        public CategoryDapperRepository(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<Category> FilterByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories WHERE Categories LIKE '%' + @CATEGORYNAME + '%'";

                return conn.Query<Category>(sQuery, new { name });
            }
        }
    }
}
