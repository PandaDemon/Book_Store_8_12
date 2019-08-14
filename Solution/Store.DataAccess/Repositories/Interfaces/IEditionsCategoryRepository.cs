using Store.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IEditionsCategoryRepository
    {
        IEnumerable<CategoryModel> AllCategories { get; }
    }
}
