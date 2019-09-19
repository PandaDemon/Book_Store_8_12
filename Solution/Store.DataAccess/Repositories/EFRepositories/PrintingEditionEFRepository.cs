using System.Collections.Generic;
using System.Linq;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using static Store.DataAccess.Entities.EntityEnum;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionEFRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionEFRepository(DataBaseContext context) : base (context)
        {
        }

        public IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            return _context.PrintingEditions.Where(x => x.CategoryId == categotyId && x.Price == filterPrice && x.Name.Contains(filterName)).AsEnumerable();
        }
        
        public IEnumerable<PrintingEdition> SortByPrice(EntityEnum sortValue)
        {
            IEnumerable<PrintingEdition> value = new List<PrintingEdition>();

            if (sortValue == Asc)
            {
                value = _context.PrintingEditions.OrderBy(x => x.Price);
            }

            if (sortValue == Desc)
            {
                value = _context.PrintingEditions.OrderByDescending(x => x.Price);
            }

            return value.AsEnumerable();
        }
    }
}
