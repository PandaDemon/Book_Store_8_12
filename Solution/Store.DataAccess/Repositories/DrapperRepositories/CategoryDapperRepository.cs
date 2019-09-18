using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class CategoryDapperRepository : ICategoryRepository
    {
        private readonly IConfiguration _config;

        public CategoryDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public void Create(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Categories (CategoryName) VALUES(@CategoryName)";

                conn.Execute(sQuery, item);
            }
        }

        public void Update(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Categories SET CategoryName = @CategoryName WHERE ID = @Id";

                conn.Execute(sQuery, item);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Categories WHERE ID = @id";
                conn.Execute(sQuery, new { id });
            }
        }

        public IEnumerable<Category> FilterByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories WHERE Categories LIKE '%' + @CATEGORYNAME + '%'";

                return conn.Query<Category>(sQuery, new { name });
            }
        }

        public Category Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories WHERE ID = @ID";

                return conn.Query<Category>(sQuery, new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories";

                return conn.Query<Category>(sQuery);
            }
        }
    }
}
