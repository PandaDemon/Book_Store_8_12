using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintStore.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<AuthorInPrintingEditions> AuthorInPrintingEditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorInPrintingEditions>().HasKey(sc => new { sc.AuthorId, sc.PrintingEditionId });

            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<Author>(sc => sc.Author)
                .WithMany()
                .HasForeignKey(sc => sc.AuthorId);


            modelBuilder.Entity<AuthorInPrintingEditions>()
                .HasOne<PrintingEdition>(sc => sc.PrintingEdition)
                .WithMany()
                .HasForeignKey(sc => sc.PrintingEditionId);

            modelBuilder.Entity<Order>()
                .HasOne<ApplicationUser>(s => s.ApplicationUser)
                .WithMany()
                .HasForeignKey(s => s.ApplicationUser);

            modelBuilder.Entity<Order>()
                .HasOne<Payment>(s => s.Payment)
                .WithOne(ad => ad.Order)
                .HasForeignKey<Payment>(ad => ad.OrderId);

			modelBuilder.Entity<PrintingEdition>()
				.HasOne<Currency>(s => s.Currency)
				.WithMany()
				.HasForeignKey(s => s.CurrencyId)
				.IsRequired();
        }
    }
}