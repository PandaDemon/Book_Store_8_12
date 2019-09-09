using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFPrintingEditionRepository
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string NameEdition { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int CurrencyId { get; set; }

        public virtual EFCurrencyRepository Currency { get; set; }
        public ICollection<AuthorInPrintingEditions> AuthorInPrintingEditions { get; set; }
    }
}
