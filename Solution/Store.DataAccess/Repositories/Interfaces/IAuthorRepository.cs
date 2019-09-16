using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {        
        //IEnumerable<Author> FilterAuthors(string filter);
        //IEnumerable<Author> SortByFirstName(string sortOrder);
        //IEnumerable<Author> SortByLastName(string sortOrder);
    }
}
