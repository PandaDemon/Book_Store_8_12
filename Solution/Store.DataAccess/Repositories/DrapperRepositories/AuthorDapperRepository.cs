using Dapper;
using Microsoft.EntityFrameworkCore;
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
    public class AuthorDapperRepository : IAuthorRepository
    {

        private readonly IConfiguration _config;

        public AuthorDapperRepository(IConfiguration config)
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

        public void Create(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";
                conn.Open();
                conn.Execute(sQuery, new { ID = item });
            }
        }

        public void Update(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";
                conn.Open();
                conn.Execute(sQuery, new { ID = item });
            }
        }

        public void Delete(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Authors WHERE Id = @id";
                conn.Open();
                conn.Execute(sQuery, new { ID = item });
            }
        }

        public  Author Get(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors WHERE ID = @ID";
                conn.Open();
                return conn.Query<Author>(sQuery, new { ID = item }).FirstOrDefault();
            }
        }

        public IEnumerable<Author> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors";
                conn.Open();
                return conn.Query<Author>(sQuery);
            }
        }

        public IEnumerable<Author> FilterByName(string firstName, string lastName)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors WHERE (FirstName LIKE '%' + @FIRSTNAME + '%') OR (LASTNAME LIKE '%' + @lastName + '%')";
                conn.Open();
                return conn.Query<Author>(sQuery, new { FIRSTNAME = firstName, LASTNAME = lastName });
            }
        }
    }
}
