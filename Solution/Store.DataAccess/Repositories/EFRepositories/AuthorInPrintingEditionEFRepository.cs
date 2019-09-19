﻿using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class AuthorInPrintingEditionEFRepository : BaseEFRepository<AuthorInPrintingEditions>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionEFRepository(DataBaseContext context) : base(context)
        {
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.AuthorId == authorId).AsEnumerable();
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId)
        {
            return _context.AuthorInPrintingEditions.Where(y => y.PrintingEdidtionId == printingEditionId).AsEnumerable();
        }
    }
}
