using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.EFRepositories;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.DrapperRepositories
{
    public class AuthorDapperRepository : IAuthorRepository
    {
        private readonly DataBaseContext _context;
        readonly DbSet<AuthorDapperRepository> _dbSet;

        public AuthorDapperRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Author item)
        {
            _context.Authors.Add(item);
            _context.SaveChanges();
        }

        public void Update(Author item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Author item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> FilterAuthors(string filter)
        {
            throw new NotImplementedException();
        }

        public Author FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Get( )
        {
            throw new NotImplementedException();
        }

        public Author Get(Author item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Author> SortByFirstName(string sortOrder)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Author> SortByLastName(string sortOrder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
