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

        public DbSet<PrintingEditionModel> PrintingEdition { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<OrderModel> Order { get; set; }
        public DbSet<PaymentModel> Payment { get; set; }


}
}
