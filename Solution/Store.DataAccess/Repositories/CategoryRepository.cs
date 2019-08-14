using Store.DataAccess.Initialization;
using Store.DataAccess.Models;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories
{
    public class CategoryRepository : IEditionsCategoryRepository
    {

        private readonly DataBaseInitialization dataBaseInitialization;


        public CategoryRepository(DataBaseInitialization dataBaseInitialization)
        {
            this.dataBaseInitialization = dataBaseInitialization;
        }


        public IEnumerable<CategoryModel> AllCategories => dataBaseInitialization.Category;
    }
}
