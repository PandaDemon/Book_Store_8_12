using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<PrintingEdition> PrintingEdition { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<AuthorInPrintingEditions> AuthorInPrintingEditions { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(sc => new { sc.RoleId, sc.UserId });


            modelBuilder.Entity<UserInRole>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UsersInRoles)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserInRole>()
                .HasOne<Role>(sc => sc.Role)
                .WithMany(s => s.UsersInRoles)
                .HasForeignKey(sc => sc.RoleId);


            modelBuilder.Entity<AuthorInPrintingEditions>().HasKey(sc => new { sc.AuthorId, sc.PrintingEdidtionId });


            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<Author>(sc => sc.Author)
                .WithMany(s => s.AuthorInPrintingEditions)
                .HasForeignKey(sc => sc.AuthorId);


            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<PrintingEdition>(sc => sc.PrintingEdition)
                .WithMany(s => s.AuthorInPrintingEditions)
                .HasForeignKey(sc => sc.PrintingEdidtionId);


            modelBuilder.Entity<Order>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Orders)
                .HasForeignKey(s => s.UserId);


            modelBuilder.Entity<Order>()
                .HasOne<Payment>(s => s.Payment)
                .WithOne(ad => ad.Order)
                .HasForeignKey<Payment>(ad => ad.OrderId);


            modelBuilder.Entity<PrintingEdition>()
                .HasOne<Currency>(s => s.Currency)
                .WithMany(g => g.PrintingEditions)
                .HasForeignKey(s => s.CurrencyId);
        }
    }
}
