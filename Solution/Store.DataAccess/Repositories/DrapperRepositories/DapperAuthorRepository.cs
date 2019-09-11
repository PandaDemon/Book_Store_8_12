using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class DapperAuthorRepository : IAuthor
    {
        private readonly DataBaseContext _context;

        public DapperAuthorRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void Create(Author item)
        {
            _context.Author.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Author author = _context.Author.Find(id);
            if (author != null)
            {
                _context.Author.Remove(author);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Author> SortByFirstName(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.Author.OrderByDescending(x => x.FirstName);

                case "high":
                    return _context.Author.OrderBy(x => x.FirstName);

            }
            throw new NotImplementedException();

        }

        public Author Get(int id)
        {
            return _context.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Author;
        }

        public IEnumerable<Author> SortByLastName(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.Author.OrderByDescending(x => x.LastName);

                case "high":
                    return _context.Author.OrderBy(x => x.LastName);

            }
            throw new NotImplementedException();
        }

        public void Update(Author item)
        {
            var updateAuthor = _context.Author.Find(item.Id);
            if (updateAuthor != null)
            {
                updateAuthor.FirstName = item.FirstName;
                updateAuthor.LastName = item.LastName;
            }
            _context.SaveChanges();
        }

        public IEnumerable<Author> FilterAuthors(string filter)
        {
            return _context.Author.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter));
        }
    }
}
