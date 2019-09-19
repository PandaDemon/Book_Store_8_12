using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseRepository<AuthorInPrintingEditions>
    {
        IEnumerable<AuthorInPrintingEditions> FindByAuthor(int authorId);
        IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(int printingEditionId);
    }
}
