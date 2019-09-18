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

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));


        public void Create(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";

                conn.Execute(sQuery, item );
            }
        }

        public void Update(Author item)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id";

                conn.Execute(sQuery, item );
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM Authors WHERE ID = @Id";

                conn.Execute(sQuery, new { id });
            }
        }

        public  Author Get(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors WHERE ID = @Id";

                return conn.Query<Author>(sQuery, new { id } ).FirstOrDefault();
            }
        }

        public IEnumerable<Author> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM Authors";

                return conn.Query<Author>(sQuery);
            }
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
