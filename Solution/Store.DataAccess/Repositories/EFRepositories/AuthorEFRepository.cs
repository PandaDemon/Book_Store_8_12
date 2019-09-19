using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class AuthorEFRepository : BaseEFRepository<Author>, IAuthorRepository
    {

        public AuthorEFRepository(DataBaseContext context) : base(context)
        {
        }

        public IEnumerable<Author> FilterByName(string firstName, string lastName)
        {
            return _context.Authors.Where(x => x.FirstName.Contains(firstName) || x.LastName.Contains(lastName)).AsEnumerable();
        }
    }
}
