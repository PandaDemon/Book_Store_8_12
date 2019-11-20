
using Microsoft.AspNetCore.Identity;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using Store.DataAccess.Initialization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.DataAccess.Initialization
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager, DataBaseContext context)
        {
            context.Database.EnsureCreated();

            string adminEmail = "admin222@gmail.com";
            string password = "123456sdff_sA";

            if (await _roleManager.FindByNameAsync("admin") == null)
            {
                await _roleManager.CreateAsync(new Role { Name = "admin" });
            }
            if (await _roleManager.FindByNameAsync("user") == null)
            {
                await _roleManager.CreateAsync(new Role { Name = "user" });
            }
            if (await _userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail, FirstName = "Djo", LastName = "Dou", Password = password };
                IdentityResult result = await _userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "admin");
                    await _userManager.CreateAsync(admin, password);
                }
            }

            if (context.Authors.Any())
            {
                return;
            }

            Order[] orders = new Order[]
            {
                new Order {DatePurchase = DateTime.Now, Description = "order 2", ApplicationUserId =  (await _userManager.FindByEmailAsync(adminEmail)).Id }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();

            Payment[] payments = new Payment[]
            {
                new Payment { IsPayed = true, PaymentNumber = 2213, OrderId = orders.First().Id }
            };

            context.Payments.AddRange(payments);
            context.SaveChanges();

            Author[] authors = new Author[]
            {
                new Author {LastName = "Bulgakov", FirstName = "Mihael" },
                new Author {LastName = "Sapkovskiy", FirstName = "Adjey"},
                new Author {LastName = "Azimov", FirstName = "Ayzek"}
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            Currency[] currency = new Currency[]
            {
                new Currency {CurrencyName = "UAN"},
                new Currency {CurrencyName = "USD"},
                new Currency {CurrencyName = "EUR"}

            };

            context.Currencies.AddRange(currency);
            context.SaveChanges();

            PrintingEdition[] printingeditions = new PrintingEdition[]
            {
                new PrintingEdition {NameEdition = "Book 1", Description = "very interesting book", Price = 20.3, Status = PrintingEditionStatus.Available, Type = PrintingEditionType.Book, ImageUrl = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = currency.First().Id},
                new PrintingEdition {NameEdition = "Magazine 1",  Description = "very interesting magazine", Price = 25.5, Status = PrintingEditionStatus.Available, Type = PrintingEditionType.Magazine, ImageUrl = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = currency.ElementAt(2).Id},
                new PrintingEdition {NameEdition = "Magazine 1", Description = "very interesting book", Price = 2290.3, Status = PrintingEditionStatus.Available, Type =PrintingEditionType.Book, ImageUrl = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html",CurrencyId = currency.ElementAt(1).Id},
                new PrintingEdition {NameEdition = "Booklet 1",Description = "very interesting news paper", Price = 10.3, Status = PrintingEditionStatus.Available, Type = PrintingEditionType.NewsPaper, ImageUrl = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = currency.ElementAt(1).Id}
            };

            context.PrintingEditions.AddRange(printingeditions);
            context.SaveChanges();

            AuthorInPrintingEditions[] authorsInPrintingEditions = new AuthorInPrintingEditions[]
            {
                new AuthorInPrintingEditions {AuthorId = authors.First().Id, PrintingEditionId = printingeditions.First().Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(1).Id, PrintingEditionId = printingeditions.ElementAt(1).Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(1).Id, PrintingEditionId = printingeditions.ElementAt(2).Id},
            };

            context.AuthorInPrintingEditions.AddRange(authorsInPrintingEditions);
            context.SaveChanges();

            PrintingEditionsInOrders[] printEditionsInOrders = new PrintingEditionsInOrders[]
            {
                new PrintingEditionsInOrders{ OrderId = orders.First().Id, PrintingEditionId = printingeditions.First().Id, PrintEditionQuantity = 2, OrderAmount = (printingeditions.First().Price)*2}
            };

            context.PrintingEditionsInOrders.AddRange(printEditionsInOrders);
            context.SaveChanges();
        }
    }
}
