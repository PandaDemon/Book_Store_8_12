using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class PrintingEditionDapperRepository /*: IPrintingEditionRepository*/
    {
        private readonly DataBaseContext _context;

        public PrintingEditionDapperRepository(DataBaseContext context)
        {
            this._context = context;
        }

        //public void Create(PrintingEdition item, Author author)
        //{
        //    item.Currency = _context.Currencies.Find(item.CurrencyId);
        //    _context.PrintingEditions.Add(item);
        //    _context.SaveChanges();
        //    var printE = _context.PrintingEditions.FirstOrDefault(x => x.Name == item.Name);
        //    var authorN = _context.Authors.FirstOrDefault(x => x.FirstName == author.FirstName && x.LastName == author.LastName);


        //    AuthorInPrintingEditions authorInPrintingEditions = new AuthorInPrintingEditions
        //    {
        //        AuthorId = authorN.Id,
        //        PrintingEdidtionId = printE.Id,
        //        Author = authorN,
        //        PrintingEdition = printE
        //    };
        //    _context.AuthorInPrintingEditions.Add(authorInPrintingEditions);
        //    _context.SaveChanges();
        //}

        public async Task DeleteAsync(int id)
        {
            var printingEdition = await _context.PrintingEditions.FindAsync(id);
            if (printingEdition != null)
            {
                _context.PrintingEditions.Remove(printingEdition);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PrintingEdition> FilterTitle(string filter)
        {
            return _context.PrintingEditions.Where(x => x.Name.Contains(filter));
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
                    return _context.PrintingEditions.OrderByDescending(x => x.Price);

                case "high":
                    return _context.PrintingEditions.OrderBy(x => x.Price);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingEdition> FilterByCategory(int sortCategory)
        {
            return _context.PrintingEditions.Where(x => x.CategoryId == sortCategory);
        }

        public PrintingEdition Get(PrintingEdition item)
        {
            return _context.PrintingEditions.Find(item);
        }

        public IEnumerable<PrintingEdition> GetAll()
        {
            return _context.PrintingEditions;
        }

        public void Update(PrintingEdition item)
        {
            var upPrintingEdition = _context.PrintingEditions.Find(item.Id);
            if (upPrintingEdition != null)
            {
                upPrintingEdition.AvatarUrl = item.AvatarUrl;
                upPrintingEdition.Name = item.Name;
                upPrintingEdition.Price = item.Price;
                upPrintingEdition.Category = item.Category;
                upPrintingEdition.Desc = item.Desc;
                upPrintingEdition.Currency = item.Currency;

                _context.PrintingEditions.Update(upPrintingEdition);
            }
        }

        public PrintingEdition FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(PrintingEdition item)
        {
            throw new NotImplementedException();
        }

        public void Delete(PrintingEdition item)
        {
            throw new NotImplementedException();
        }
    }
}
