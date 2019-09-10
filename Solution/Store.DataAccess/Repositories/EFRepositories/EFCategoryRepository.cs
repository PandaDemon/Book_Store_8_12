using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFCategoryRepository 
    {
        //private readonly DataBaseContext _context;
        //public EFCategoryRepository(DataBaseContext context)
        //{
        //    this._context = context;
        //}

        //public IEnumerable<Category> GetAllCategory(bool includePrintingEdition = false)
        //{
        //    //if (includePrintingEdition)
        //    //{
        //    //    return _context.Set<Category>().Include(x => x.PrintingEdition).AsNoTracking().ToList();
        //    //}

        //    //else
        //    //{
        //    //    return _context.Category.ToList();
        //    //}
        //}

        //public Category GetCategoryById(int categoryId, bool includePrintingEdition = false)
        //{
        //    //if (includePrintingEdition)
        //    //{
        //    //    return _context.Set<Category>().Include(x => x.PrintingEdition).AsNoTracking().FirstOrDefault(x => x.Id == categoryId);
        //    //}
        //    //else
        //    //{
        //    //    return _context.Category.FirstOrDefault(x => x.Id == categoryId);
        //    //}

        //}

        //public void SaveCategory(Category category)
        //{
        //    if (category.Id == 0)
        //    {
        //        _context.Category.Add(category);
        //    }
        //    else
        //    {
        //        _context.Entry(category).State = EntityState.Modified;
        //        _context.SaveChanges();
        //    }
        //}

        //public void DeleteCategory(Category category)
        //{
        //    _context.Category.Remove(category);
        //    _context.SaveChanges();
        //}
    }
}
