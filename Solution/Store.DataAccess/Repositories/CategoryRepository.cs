using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.DataAccess.Repositories
{
    public class CategoryRepository : IEditionsCategoryRepository
    {

        private readonly DataBaseContext dataBaseInitialization;

        public CategoryRepository(DataBaseContext dataBaseInitialization)
        {
            this.dataBaseInitialization = dataBaseInitialization;
        }

        public IEnumerable<Category> AllCategories => dataBaseInitialization.Category;
    }
}
