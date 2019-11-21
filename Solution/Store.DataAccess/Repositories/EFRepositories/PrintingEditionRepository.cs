using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Base;
using PrintStore.DataAccess.Repositories.Interfaces;
using Store.DataAccess.Initialization;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PrintStore.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {

        public PrintingEditionRepository(DataBaseContext context) : base(context)
        {
        }

        public IEnumerable<PrintingEdition> FilterTitle(string filter)
        {
            return Context.PrintingEditions.Where(printEd => printEd.NameEdition.Contains(filter));
        }

        public IEnumerable<PrintingEdition> FilterByAuthor(string authorName)
        {
            IQueryable<PrintingEdition> result = Context.AuthorInPrintingEditions
                .Where(authInPe => authInPe.Author.LastName == authorName)
                .Select(authInPe => authInPe.PrintingEdition);

            return result;
        }

        public IEnumerable<PrintingEdition> SortPrintEdidtionsByPrice(SortOrder sortOrder)
        {
            if (SortOrder.Descending == sortOrder)
            {
                return Context.PrintingEditions.OrderByDescending(print => print.Price);
            }

            if (SortOrder.Ascending == sortOrder)
            {
                return Context.PrintingEditions.OrderBy(print => print.Price);
            }

            return null;
        }

        public IEnumerable<PrintingEdition> FilterByType(PrintingEditionType typeName)
        {
            return Context.PrintingEditions.Where(print => print.Type == typeName);
        }

        public IEnumerable<PrintingEdition> FilterPrintEdidtionsByPriceAnfType(PrintingEditionType printingEditionType, int minPrice, int maxPrice)
        {
            return Context.PrintingEditions
                .Where(print => print.Type == printingEditionType && (print.Price >= minPrice && print.Price <= maxPrice));
        }
    }
}
