using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository: IBaseRepository<AuthorInPrintingEditions>
    {
        IEnumerable<AuthorInPrintingEditions> GetWithInclude();
        IEnumerable<AuthorInPrintingEditions> FindByAuthor(int id);
        IEnumerable<AuthorInPrintingEditions> FindByPrintingEditionID(int id);
        void DeleteAuthorInPe(IEnumerable<AuthorInPrintingEditions> items);
        void AddAuthorInPe(IEnumerable<AuthorInPrintingEditions> items);
        IEnumerable<AuthorInPrintingEditions> SortPriceInRange(int sortPriceFrom, int sortPriceTo, int firstElement, int lastElement);
        IEnumerable<AuthorInPrintingEditions> GetAuthorsInPrintingEditionsPage(int firstElementId, int lastElementId);
        Task<int> GetCountOfEditionsInStoreAsync();
        IEnumerable<AuthorInPrintingEditions> SortAndFilterData(SortOrder sortOrder, string sortedElement, int firstElement, int lastElement, 
            string filter, PrintingEditionType type, PrintingEditionStatus status);
        IEnumerable<AuthorInPrintingEditions> FilterData(string filter, string filteredElement, int firstElement, int lastElement);
    }
}
