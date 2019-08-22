using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEdition
    {
        IEnumerable<PrintingEdition> GetAllPrintingEdition(bool includeCategory = false);
        PrintingEdition GetPrintingEditionById(int printingEditionId, bool includeCategory = false);
        void SavePrintingEdition(PrintingEdition printingEdition);
        void DeletePrintingEdition(PrintingEdition printingEdition);
    }
}
