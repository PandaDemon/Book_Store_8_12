using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author Get(int id);
        IEnumerable<Author> FilterAuthors(string filter);
        IEnumerable<Author> SortByFirstName(string sortOrder);
        IEnumerable<Author> SortByLastName(string sortOrder);
        void Create(Author item);
        void Update(Author item);
        void Delete(int id);
    }
}
