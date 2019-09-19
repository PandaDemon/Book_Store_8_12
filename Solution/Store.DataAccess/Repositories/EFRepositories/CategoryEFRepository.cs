using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class CategoryEFRepository : BaseEFRepository<Category>, ICategoryRepository
    {
        public CategoryEFRepository(DataBaseContext context) : base(context)
        {
        }

        public IEnumerable<Category> FilterByName(string name)
        {
            return _dbSet.Where(x => x.Name.Contains(name)).AsEnumerable();
        }
    }
}
