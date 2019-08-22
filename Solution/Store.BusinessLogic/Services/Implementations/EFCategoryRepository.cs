using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using System.Collections.Generic;
using System.Linq;

namespace Store.BusinessLogic.Services.Implementations
{
    public class EFCategoryRepository : ICategory
    {
        private DataBaseContext context;
        public EFCategoryRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetAllCategory(bool includePrintingEdition = false)
        {
            if (includePrintingEdition)
            {
                return context.Set<Category>().Include(x => x.PrintingEdition).AsNoTracking().ToList();
            }

            else
            {
                return context.Category.ToList();
            }
        }

        public Category GetCategoryById(int categoryId, bool includePrintingEdition = false)
        {
            if (includePrintingEdition)
            {
                return context.Set<Category>().Include(x => x.PrintingEdition).AsNoTracking().FirstOrDefault(x => x.Id == categoryId);
            }
            else
            {
                return context.Category.FirstOrDefault(x => x.Id == categoryId);
            }
            
        }

        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                context.Category.Add(category);
            }
            else
            {
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(Category category)
        {
            context.Category.Remove(category);
            context.SaveChanges();
        }
    }
}
