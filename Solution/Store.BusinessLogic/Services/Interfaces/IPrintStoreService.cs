using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities.Enums;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintStoreService
    {
        Task<IEnumerable<PrintingEditionViewModel>> GetAuthorPrintingEditions(int authorId, string currentCurrencyName);
        IEnumerable<AuthorViewModel> SearchAuthors(string searchString, string currentCurrencyName);
        IEnumerable<AuthorsInPrintingEditionsViewModel> GetAuthorsInPrintingEditionsPage(int firstElement, int lastElement, string currentCurrencyName);
        AuthorsInPrintingEditionsViewModel GetPrintingEditionByIdInclude(int id, string currentCurrencyName);
        Task<int> GetCountOfEditionsInStoreAsync();
        IEnumerable<AuthorsInPrintingEditionsViewModel> FilterData(string filter, string currentCurrencyName, int firstElement, int lastElement, string column);
        IEnumerable<AuthorsInPrintingEditionsViewModel> SortPriceInRange(int sortPriceFrom, int sortPriceTo, string currentCurrencyName, int firstElement, int lastElement);
        IEnumerable<AuthorsInPrintingEditionsViewModel> GetAllWithCurrencyConvert(string currencyName, int firstElement, int lastElement);
        IEnumerable<AuthorsInPrintingEditionsViewModel> SortAndFilterData(SortOrder sortOrder, string currentCurrencyName, 
            string column, int firstElement, int lastElement, string filter, PrintingEditionType type, PrintingEditionStatus status);
        Task<IEnumerable<CurrencyViewModel>> GetCurrencies();
    }
}
