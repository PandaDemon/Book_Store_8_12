using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class DapperPrintingEditionRepository : IPrintingEdition
    {
        private readonly DataBaseContext _context;

        public DapperPrintingEditionRepository(DataBaseContext context)
        {
            this._context = context;
        }

        public void Create(PrintingEdition item, Author author)
        {
            item.Currency = _context.Currency.Find(item.CurrencyId);
            _context.PrintingEdition.Add(item);
            _context.SaveChanges();
            var printE = _context.PrintingEdition.FirstOrDefault(x => x.Name == item.Name);
            var authorN = _context.Author.FirstOrDefault(x => x.FirstName == author.FirstName && x.LastName == author.LastName);


            AuthorInPrintingEditions authorInPrintingEditions = new AuthorInPrintingEditions
            {
                AuthorId = authorN.Id,
                PrintingEdidtionId = printE.Id,
                Author = authorN,
                PrintingEdition = printE
            };
            _context.AuthorInPrintingEditions.Add(authorInPrintingEditions);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var printingEdition = await _context.PrintingEdition.FindAsync(id);
            if (printingEdition != null)
            {
                _context.PrintingEdition.Remove(printingEdition);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PrintingEdition> FilterTitle(string filter)
        {
            return _context.PrintingEdition.Where(x => x.Name.Contains(filter));
        }

        public IEnumerable<PrintingEdition> FilterByAuthor(string authorName)
        {

            var result = _context.AuthorInPrintingEditions.Where(x => x.Author.LastName == authorName).Select(c => c.PrintingEdition);

            return result;
        }

        public IEnumerable<PrintingEdition> FilterByPrice(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.PrintingEdition.OrderByDescending(x => x.Price);

                case "high":
                    return _context.PrintingEdition.OrderBy(x => x.Price);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingEdition> FilterByCategory(int sortCategory)
        {
            return _context.PrintingEdition.Where(x => x.CategoryId == sortCategory);
        }

        public PrintingEdition Get(int id)
        {
            return _context.PrintingEdition.Find(id);
        }

        public IEnumerable<PrintingEdition> GetAll()
        {
            return _context.PrintingEdition;
        }

        public void Update(PrintingEdition item)
        {
            var upPrintingEdition = _context.PrintingEdition.Find(item.Id);
            if (upPrintingEdition != null)
            {
                upPrintingEdition.Img = item.Img;
                upPrintingEdition.Name = item.Name;
                upPrintingEdition.Price = item.Price;
                upPrintingEdition.IsInStock = item.IsInStock;
                upPrintingEdition.Category = item.Category;
                upPrintingEdition.Desc = item.Desc;
                upPrintingEdition.Currency = item.Currency;

                _context.PrintingEdition.Update(upPrintingEdition);
            }
        }
    }
}
