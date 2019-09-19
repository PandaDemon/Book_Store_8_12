using Store.DataAccess.Entities;
using System.Collections.Generic;
using static Store.DataAccess.Entities.EntityEnum;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName);
        IEnumerable<PrintingEdition> SortByPrice(EntityOrdering sortValue);
    }
}
