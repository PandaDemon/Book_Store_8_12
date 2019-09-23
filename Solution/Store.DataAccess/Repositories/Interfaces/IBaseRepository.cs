using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
