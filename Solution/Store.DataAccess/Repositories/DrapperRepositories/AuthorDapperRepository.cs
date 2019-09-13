using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorDapperRepository : IAuthorRepository
    {
        private readonly DataBaseContext _context;

        public AuthorDapperRepository(DataBaseContext context)
        {
            _context = context;
        }
        public void Create(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Author> SortByFirstName(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.Authors.OrderByDescending(x => x.FirstName);

                case "high":
                    return _context.Authors.OrderBy(x => x.FirstName);

            }
            throw new NotImplementedException();
        }

        public Author Get(int id)
        {
            return _context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public IEnumerable<Author> SortByLastName(string sortOrder)
        {
            switch (sortOrder)
            {
                case "low":
                    return _context.Authors.OrderByDescending(x => x.LastName);

                case "high":
                    return _context.Authors.OrderBy(x => x.LastName);
            }
            throw new NotImplementedException();
        }

        public void Update(Author item)
        {
            var updateAuthor = _context.Authors.Find(item.Id);
            if (updateAuthor != null)
            {
                updateAuthor.FirstName = item.FirstName;
                updateAuthor.LastName = item.LastName;
            }
            _context.SaveChanges();
        }

        public IEnumerable<Author> FilterAuthors(string filter)
        {
            return _context.Authors.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter));
        }
    }
}
