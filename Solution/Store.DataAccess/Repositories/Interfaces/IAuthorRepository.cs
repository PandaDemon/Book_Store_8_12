
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Base;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository: IBaseRepository<Author>
    {
        IEnumerable<Author> FilterAuthors(string filter);
        IEnumerable<Author> SortByName(SortOrder sortOrder, string sortedElement);
    }
}
