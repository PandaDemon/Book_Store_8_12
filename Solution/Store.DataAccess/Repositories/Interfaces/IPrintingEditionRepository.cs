using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName);
        IEnumerable<PrintingEdition> SortByPrice(string sortValue);
    }
}
