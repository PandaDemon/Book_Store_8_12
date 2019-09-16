using System.Collections.Generic;
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



        //TO DO FilTER!!!!!!!!!!!!!!!!!!!!!!!!
        public IEnumerable<PrintingEdition> FilterForPrintingEdition(string filterCategoty, double filterPrice, string filterName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PrintingEdition> SortByPrice(double price)
        {
            throw new System.NotImplementedException();
        }
    }
}
