using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TEntity item);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
