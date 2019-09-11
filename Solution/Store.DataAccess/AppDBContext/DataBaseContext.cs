using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<PrintingEdition> PrintingEdition { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<AuthorInPrintingEditions> AuthorInPrintingEditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorInPrintingEditions>().HasKey(sc => new { sc.AuthorId, sc.PrintingEdidtionId });

            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<Author>(sc => sc.Author)
                .WithMany()
                .HasForeignKey(sc => sc.AuthorId);


            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<PrintingEdition>(sc => sc.PrintingEdition)
                .WithMany()
                .HasForeignKey(sc => sc.PrintingEdidtionId);

            modelBuilder.Entity<PrintingEdition>()
                .HasOne<Category>(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne<User>(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Order>()
                .HasOne<Payment>(s => s.Payment)
                .WithOne(ad => ad.Order)
                .HasForeignKey<Payment>(ad => ad.OrderId);

            modelBuilder.Entity<PrintingEdition>()
                .HasOne<Currency>(s => s.Currency)
                .WithMany()
                .HasForeignKey(s => s.CurrencyId);
        }
    }
}