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

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public void Create(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Categories (CategoryName) VALUES(@CategoryName)";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Update(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Categories SET CategoryName = @CategoryName WHERE ID = @Id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public void Delete(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Categories WHERE ID = @id";
                conn.Open();
                conn.Execute(sQuery, item);
            }
        }

        public IEnumerable<Category> FilterByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories WHERE Categories LIKE '%' + @CATEGORYNAME + '%'";
                conn.Open();
                return conn.Query<Category>(sQuery, name);
            }
        }

        public Category Get(Category item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories WHERE ID = @ID";
                conn.Open();
                return conn.Query<Category>(sQuery, item).FirstOrDefault();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Categories";
                conn.Open();
                return conn.Query<Category>(sQuery);
            }
        }
    }
}
