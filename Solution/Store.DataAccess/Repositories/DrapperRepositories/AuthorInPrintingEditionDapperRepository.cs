using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorInPrintingEditionDapperRepository : IAuthorInPrintingEditionRepository
    {
        private readonly IConfiguration _config;

        public AuthorInPrintingEditionDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));


        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AuthorInPrintingEditions WHERE AuthorId = @AuthorId";

                return conn.Query<AuthorInPrintingEditions>(sQuery, new { authorId});
            }
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AuthorInPrintingEditions WHERE PrintingEditionId = @PrintingEditionId";

                return conn.Query<AuthorInPrintingEditions>(sQuery, new { printingEditionId });
            }
        }
    }
}
