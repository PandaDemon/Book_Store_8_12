using Store.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAllEditions
    {
        IEnumerable<PrintingEdition> PrintingEditions { get; }

        PrintingEdition getObjectEdition(int EditionId);


    }
}
