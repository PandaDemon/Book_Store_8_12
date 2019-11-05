using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task Create(TEntity item)
        {
			await _dbSet.AddAsync(item);
			await _context.SaveChangesAsync();
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity tEntiry = _dbSet.Find(id);
            if (tEntiry != null)
            {
                _context.Remove(tEntiry);

                _context.SaveChanges();
            }
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
    }
}
