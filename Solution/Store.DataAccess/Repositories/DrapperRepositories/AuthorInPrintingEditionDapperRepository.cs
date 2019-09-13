using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorInPrintingEditionDapperRepository : IAuthorInPrintingEditionRepository
    {
        private readonly DataBaseContext _context;

        public AuthorInPrintingEditionDapperRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthorInPrintingEditions> FilterByAuthor(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.AuthorInPrintingEditions.OrderByDescending(x => x.Author.LastName);

                case "high":
                    return _context.AuthorInPrintingEditions.OrderBy(x => x.Author.LastName);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorInPrintingEditions> SortByPrintingEditionName(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.AuthorInPrintingEditions.OrderByDescending(x => x.PrintingEdition.Name);

                case "high":
                    return _context.AuthorInPrintingEditions.OrderBy(x => x.PrintingEdition.Name);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionPrice(string filterType)
        {
            switch (filterType)
            {
                case "high":
                    return _context.AuthorInPrintingEditions.OrderByDescending(x => x.PrintingEdition.Price);

                case "low":
                    return _context.AuthorInPrintingEditions.OrderBy(x => x.PrintingEdition.Price);

            }
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionCategory(int categoryId)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.PrintingEdition.CategoryId == categoryId);
        }

        public IEnumerable<AuthorInPrintingEditions> FilterByPrintingEditionName(string name)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.PrintingEdition.Name.Contains(name));
        }

        public IEnumerable<AuthorInPrintingEditions> FindByAuthor(string authorName)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.Author.LastName == authorName);
        }

        public IEnumerable<AuthorInPrintingEditions> FindByPrintingEdition(string name)
        {
            return _context.AuthorInPrintingEditions.Where(x => x.PrintingEdition.Name == name);
        }
        public IEnumerable<Author> FindByPrintingEditionID(int id)
        {
            return null;
        }

        public AuthorInPrintingEditions Get(int id)
        {
            return _context.AuthorInPrintingEditions.Find(id);
        }

        public IEnumerable<AuthorInPrintingEditions> GetAll()
        {
            var result = _context.AuthorInPrintingEditions.ToList();
            return result;
        }
    }
}
