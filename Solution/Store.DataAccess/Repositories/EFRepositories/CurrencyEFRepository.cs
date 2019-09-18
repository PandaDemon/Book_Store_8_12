﻿using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

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

        public void Delete(int id)
        {
            Currency currencies = _context.Currencies.Find(id);
            if (currencies != null)
            {
                _context.Currencies.Remove(currencies);
                _context.SaveChanges();
            }
        }
        public Currency Get(int id)
        {
            return _context.Currencies.Find(id);
        }

        public IEnumerable<Currency> GetAll()
        {
            return _context.Currencies;
        }
    }
}
