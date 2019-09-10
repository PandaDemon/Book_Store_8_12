using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintStoreService
    {
        IEnumerable<AuthorModel> GetAllAuthors();
        IEnumerable<PrintingEditionModel> GetAllPrintingEditions();
        IEnumerable<AuthorsInPrintingEditionsModel> GetAllAuthorsInPrintingEditions();
        IEnumerable<PrintingEditionModel> GetAuthorPrintingEditions(string authorName);

        IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionType(string filterType);

        IEnumerable<AuthorsInPrintingEditionsModel> SortByPrintingEditionPrice(string filterType);

        IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionTitle(string filter);

        IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionStatus(string filter);

        IEnumerable<AuthorsInPrintingEditionsModel> FilterByAuthor(string filter);

    }
}
