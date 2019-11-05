using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> Get(int id);
        Task Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
