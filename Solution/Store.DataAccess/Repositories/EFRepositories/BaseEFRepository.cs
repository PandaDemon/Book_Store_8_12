using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class BaseEFRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataBaseContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseEFRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);

            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);

            _context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            TEntity tEntiry = _dbSet.Find(item);
            if (tEntiry != null)
            {
                _context.Remove(tEntiry);

                _context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
    }
}
