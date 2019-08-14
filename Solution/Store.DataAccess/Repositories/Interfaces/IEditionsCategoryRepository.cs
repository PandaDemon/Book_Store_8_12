using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IEditionsCategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
