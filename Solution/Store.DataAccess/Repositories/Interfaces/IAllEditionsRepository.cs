using Store.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAllEditionsRepository
    {
        IEnumerable<PrintingEditionModel> PrintingEditions { get; }

        PrintingEditionModel getObjectEdition(int EditionId);
    }
}
