using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories
{
    //public class PrintingEditionRepository : IAllEditionsRepository
    //{
        //private readonly DataBaseContext dataBaseInitialization;

        //public PrintingEditionRepository(DataBaseContext dataBaseInitialization)
        //{
        //    this.dataBaseInitialization = dataBaseInitialization;
        //}

        //public IEnumerable<PrintingEdition> PrintingEditions => dataBaseInitialization.PrintingEdition.Include(c => c.Category);

        //public PrintingEdition getObjectEdition(int EditionId) => dataBaseInitialization.PrintingEdition.FirstOrDefault(p => p.Id == EditionId);





        //private DataBaseContext db;

        //public PrintingEditionRepository(DataBaseContext context)
        //{
        //    this.db = context;
        //}

        //public IEnumerable<PrintingEdition> GetAll()
        //{
        //    return db.PrintingEdition.Include(o => o.Category);
        //}

        //public PrintingEdition Get(int id)
        //{
        //    return db.PrintingEdition.Find(id);
        //}

        //public void Create(PrintingEdition edition)
        //{
        //    db.PrintingEdition.Add(edition);
        //}

        //public void Update(PrintingEdition order)
        //{
        //    db.Entry(order).State = EntityState.Modified;
        //}
        //public IEnumerable<PrintingEdition> Find(Func<PrintingEdition, Boolean> predicate)
        //{
        //    return db.PrintingEdition.Include(o => o.Category).Where(predicate).ToList();
        //}
        //public void Delete(int id)
        //{
        //    PrintingEdition order = db.PrintingEdition.Find(id);
        //    if (order != null)
        //        db.PrintingEdition.Remove(order);
        //}
    //}
}
