using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategory(bool includePrintingEdition = false);
        Category GetCategoryById(int сategoryId, bool includePrintingEdition = false);
        void SaveCategory(Category сategory);
        void DeleteCategory(Category сategory);
    }
}
