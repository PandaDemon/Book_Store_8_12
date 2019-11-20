using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(int id);
        Task Update(TEntity item);
    }
}
