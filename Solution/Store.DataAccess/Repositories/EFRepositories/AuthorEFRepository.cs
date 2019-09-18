using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class AuthorEFRepository : IAuthorRepository
    {
        readonly DataBaseContext _context;

        public AuthorEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public void Update(Author item)
        {
            _context.Entry(item).State = EntityState.Modified;
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

        public Author Get(int id)
        {
            return _context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.AsEnumerable();
        }

        public IEnumerable<Author> FilterByName(string firstName, string lastName)
        {
            return _context.Authors.Where(x => x.FirstName.Contains(firstName) || x.LastName.Contains(lastName));
        }
    }
}
