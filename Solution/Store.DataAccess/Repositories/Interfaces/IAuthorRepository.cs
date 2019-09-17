using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {        
        IEnumerable<Author> FilterByName(string firstName, string lastName);
    }
}
