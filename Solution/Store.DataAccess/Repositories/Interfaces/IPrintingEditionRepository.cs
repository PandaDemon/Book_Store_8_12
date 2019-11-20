using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository: IBaseRepository<PrintingEdition>
    {
        IEnumerable<PrintingEdition> SortPrintEdidtionsByPrice(SortOrder sortOrder);
        IEnumerable<PrintingEdition> FilterPrintEdidtionsByPriceAnfType(PrintingEditionType printingEditionType, int minPrice, int maxPrice);
        IEnumerable<PrintingEdition> FilterByType(PrintingEditionType printingEditionType);
        IEnumerable<PrintingEdition> FilterTitle(string filter);
    }
}
