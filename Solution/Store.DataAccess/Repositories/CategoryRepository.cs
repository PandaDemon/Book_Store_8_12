using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories
{
    //public class InitializeCategoryRepository : IEditionsCategoryRepository
    //{
    //    private readonly DataBaseContext dataBaseInitialization;

    //    public InitializeCategoryRepository(DataBaseContext dataBaseInitialization)
    //    {
    //        this.dataBaseInitialization = dataBaseInitialization;
    //    }

        //public IEnumerable<Category> AllCategories => dataBaseInitialization.Category;
    //}

    //public class CategoryRepository : IRepository<Category>
    //{
    //    private DataBaseContext db;

    //    public CategoryRepository(DataBaseContext context)
    //    {
    //        this.db = context;
    //    }

    //    public IEnumerable<Category> GetAll()
    //    {
    //        return db.Category;
    //    }

    //    public Category Get(int id)
    //    {
    //        return db.Category.Find(id);
    //    }

    //    public void Create(Category item)
    //    {
    //        db.Category.Add(item);
    //    }

    //    public void Update(Category item)
    //    {
    //        db.Entry(item).State = EntityState.Modified;
    //    }

    //    public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
    //    {
    //        return db.Category.Where(predicate).ToList();
    //    }

    //    public void Delete(int id)
    //    {
    //        Category item = db.Category.Find(id);
    //        if (item != null)
    //        {
    //            db.Category.Remove(item);
    //        }
    //    }      
    //}
}
