using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class AuthorInPrintingEditionEFRepository : IAuthorInPrintingEditionRepository
    {
        private readonly DataBaseContext _context;

        public AuthorInPrintingEditionEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.AuthorId == authorId);
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId)
        {
            return _context.AuthorInPrintingEditions.Where(y => y.PrintingEdidtionId == printingEditionId);
        }
    }
}
