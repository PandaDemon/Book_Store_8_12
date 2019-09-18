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
        IEnumerable<AuthorsInPrintingEditionsModel> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName);
        IEnumerable<AuthorsInPrintingEditionsModel> SortPrintingEditionByPrice(string sortValue);
    }
}
