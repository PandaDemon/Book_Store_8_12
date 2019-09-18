using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseRepository<PrintingEdition>
    {
        IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName);
        IEnumerable<PrintingEdition> SortByPrice(Enum sortValue);
    }
}
