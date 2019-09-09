using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFCurrencyRepository
    {
        public int Id { get; set; }

        public string CurrencyName { get; set; }
        public ICollection<EFPrintingEditionRepository> PrintingEditions { get; set; }
    }
}
