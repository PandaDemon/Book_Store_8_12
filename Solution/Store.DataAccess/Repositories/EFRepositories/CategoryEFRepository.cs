using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class CategoryEFRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;
        public CategoryEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
            _context.SaveChanges();
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Category item)
        {
            Category category = _context.Categories.Find(item);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category Get(Category item)
        {
            return _context.Categories.Find(item);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public IEnumerable<Category> FilterByName(string name)
        {
            return _context.Categories.Where(x => x.Name.Contains(name));
        }
    }
}
