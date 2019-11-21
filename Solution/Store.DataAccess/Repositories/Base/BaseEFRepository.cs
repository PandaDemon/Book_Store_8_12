using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Initialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.Base
{
    public class BaseEFRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DataBaseContext Context;

        private readonly DbSet<TEntity> _table;

        public BaseEFRepository(DataBaseContext context)
        {
            Context = context;

            _table = context.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _table.AddAsync(item);

            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TEntity entity = await _table.FindAsync(id);

            if (entity != null)
            {
                _table.Remove(entity);

                await Context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(int id)
        {
            _table.AsNoTracking();

            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task Update(TEntity item)
        {
            _table.Attach(item);

            Context.Entry(item).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }
    }
}
