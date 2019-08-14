using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAllEditionsRepository
    {
        IEnumerable<PrintingEdition> PrintingEditions { get; }

        PrintingEdition getObjectEdition(int EditionId);
        
    }
}
