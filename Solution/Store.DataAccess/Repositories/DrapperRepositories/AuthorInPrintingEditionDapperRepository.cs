using Dapper;
using Microsoft.Extensions.Configuration;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorInPrintingEditionDapperRepository : BaseDapperRepository<AuthorInPrintingEditions>, IAuthorInPrintingEditionRepository
    {

        public AuthorInPrintingEditionDapperRepository(IConfiguration config) :base(config)
        {
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AuthorInPrintingEditions WHERE AuthorId = @AuthorId";

                return conn.Query<AuthorInPrintingEditions>(sQuery, new { authorId}).AsEnumerable();
            }
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AuthorInPrintingEditions WHERE PrintingEditionId = @PrintingEditionId";

                return conn.Query<AuthorInPrintingEditions>(sQuery, new { printingEditionId }).AsEnumerable();
            }
        }

		public IEnumerable<AuthorInPrintingEditions> GetInclude()
		{
			using(IDbConnection conn = Connection)
			{
				string sQuery = "SELECT* FROM AuthorInPrintingEditions JOIN PrintingEditions ON PrintingEditions.Id = AuthorInPrintingEditions.PrintingEditionId JOIN Authors ON Authors.Id = AuthorInPrintingEditions.AuthorId";
				return conn.Query<AuthorInPrintingEditions>(sQuery).AsEnumerable();
			}
		}
    }
}
