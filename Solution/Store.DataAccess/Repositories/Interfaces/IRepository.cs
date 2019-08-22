using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<PrintingEdition> PrintingEditions { get; }
        void Save();
    }

    public interface IEditionsCategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }

    public interface IAllEditionsRepository
    {
        IEnumerable<PrintingEdition> PrintingEditions { get; }

        PrintingEdition getObjectEdition(int EditionId);

    }
}