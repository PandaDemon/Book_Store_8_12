using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionEFRepository : IPrintingEditionRepository
    {
        readonly DataBaseContext _context;

        public PrintingEditionEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(PrintingEdition item)
        {
            _context.PrintingEditions.Add(item);
            _context.SaveChanges();
        }
        public void Update(PrintingEdition item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(PrintingEdition item)
        {
            PrintingEdition printingEdition = _context.PrintingEditions.Find(item);
            if (printingEdition != null)
            {
                _context.PrintingEditions.Remove(printingEdition);
                _context.SaveChanges();
            }
        }

        public PrintingEdition Get(PrintingEdition item)
        {
            return _context.PrintingEditions.Find(item);
        }

        public IEnumerable<PrintingEdition> GetAll()
        {
            return _context.PrintingEditions;
        }

        public IEnumerable<PrintingEdition> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            return _context.PrintingEditions.Where(x => x.CategoryId == categotyId && x.Price == filterPrice && x.Name.Contains(filterName));
        }

        public IEnumerable<PrintingEdition> SortByPrice(string sortValue)
        {
            if (sortValue == "high")
            {
                return _context.PrintingEditions.OrderBy(x => x.Price);
            }
            else
            {
                return _context.PrintingEditions.OrderByDescending(x => x.Price);
            }

        }
    }
}
