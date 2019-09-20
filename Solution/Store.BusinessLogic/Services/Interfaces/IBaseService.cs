using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
    }
}
