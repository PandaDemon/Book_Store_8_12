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

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId)
        {
            throw new NotImplementedException();
        }
    }
}
