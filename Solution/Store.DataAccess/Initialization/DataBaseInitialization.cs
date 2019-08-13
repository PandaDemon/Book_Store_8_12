using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization : DbContext
    {
        public DataBaseInitialization(DbContextOptions<DataBaseInitialization> options) : base(options)
        {

        }

        public DbSet<PrintingEdition> PrintingEdition { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
