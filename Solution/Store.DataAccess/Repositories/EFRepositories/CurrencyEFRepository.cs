using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class CurrencyEFRepository : ICurrencyRepository
    {
        readonly DataBaseContext _context;

        public CurrencyEFRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Create(Currency item)
        {
            _context.Currencies.Add(item);
            _context.SaveChanges();
        }

        public void Update(Currency item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Currency item)
        {
            Currency currencies = _context.Currencies.Find(item);
            if (currencies != null)
            {
                _context.Currencies.Remove(currencies);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Currency> Find(Func<Currency, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Currency Get(Currency item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Currency> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}
