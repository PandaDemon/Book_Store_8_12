using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInPrintingEdition
    {
        IEnumerable<AuthorInPrintingEditions> GetAll();
        AuthorInPrintingEditions Get(int id);
        IEnumerable<AuthorInPrintingEditions> FindByAuthor(string authorName);

        IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(string name);
        IEnumerable<Author> FindByPrintingEditionID(int id);

        IEnumerable<AuthorInPrintingEditions> FilterByAuthor(string sortOrder);

        IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionPrice(string filterType);

        IEnumerable<AuthorInPrintingEditions> SortByPrintingEditionName(string sortOrder);

        IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionName(string sortOrder);

        IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionCategory(int categoryId);

        IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionIsInStock(bool isInStock);
    }
}
