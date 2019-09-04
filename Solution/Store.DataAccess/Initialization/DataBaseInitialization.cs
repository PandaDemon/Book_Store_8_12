using Microsoft.AspNetCore.Identity;
using Store.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            //var users = new User
            //{
            //    UserName = "Michael",
            //    Email = "mpanukov@gmail.com",
            //    Password = "password",
            //    FirstName = "Michael",
            //    LastName = "Panukov"
            //};
            //context.User.AddRange(users);
            //context.SaveChanges();

            //    var authors = new Author[]
            //    {
            //        new Author {LastName = "Тумановский", FirstName = "Ежи" },
            //        new Author {LastName = "Дядищев ", FirstName = "Александр"},
            //        new Author {LastName = "Conan-Doyle ", FirstName = "Arthur"},
            //        new Author {LastName = "Kristi", FirstName = "Agata"},
            //        new Author {FirstName = "Magazines", LastName = "Magazines"},
            //        new Author {FirstName = "Newspapers", LastName = "Newspapers"}
            //    };
            //    context.Author.AddRange(authors);
            //    context.SaveChanges();


            //    var currency = new Currency[]
            //    {
            //        new Currency {Name = "UAN"},
            //        new Currency {Name = "USD"},
            //        new Currency {Name = "EUR"}

            //    };
            //    context.Currency.AddRange(currency);
            //    context.SaveChanges();

            //    var categoty = new Category[]
            //    {
            //        new Category { Name = "book"},
            //        new Category { Name = "magazine"},
            //        new Category { Name = "newspaper"}
            //    };
            //    context.Category.AddRange(categoty);
            //    context.SaveChanges();

            //    var printingeditions = new PrintingEdition[]
            //    {
            //        new PrintingEdition {Name = "Клык", Desc= "interesting book", Price = 20.3, IsInStock = true, Quantity = 3, CategoryId = categoty.First().Id, Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg", CurrencyId = currency.First().Id },
            //        new PrintingEdition {Name = "Клык", Desc= "interesting book", Price = 20.3, IsInStock = true, Quantity = 3, CategoryId = categoty.First().Id, Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg", CurrencyId = currency.First().Id },
            //        new PrintingEdition {Name = "Death on the Nile",  Desc = "interesting book", IsInStock = true, Quantity = 3, Price = 25.5, CategoryId = categoty.First().Id, Img = "https://upload.wikimedia.org/wikipedia/en/9/96/Death_on_the_Nile_First_Edition_Cover_1937.jpg", CurrencyId = currency.ElementAt(1).Id },
            //        new PrintingEdition {Name = "The Hound of the Baskervilles", Desc = "interesting book", IsInStock = true, Quantity = 3, Price = 2290.3, CategoryId = categoty.First().Id, Img = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Cover_%28Hound_of_Baskervilles%2C_1902%29.jpg",CurrencyId = currency.ElementAt(1).Id },
            //        new PrintingEdition {Name = "The Times", Desc = "newspaper", Price = 2.30, IsInStock = true, Quantity = 3, CategoryId = categoty.Last().Id, Img = "https://www.historic-newspapers.co.uk/images/newspapers/lrg-newspaper.jpg",CurrencyId = currency.ElementAt(1).Id },
            //        new PrintingEdition {Name = "Food & Wine", Desc = "interesting magazine", IsInStock = false, Quantity = 3, Price = 5.0, CategoryId = categoty.ElementAt(2).Id, Img = "https://images-na.ssl-images-amazon.com/images/I/61OkFg4sOGL._SY445_.jpg", CurrencyId = currency.ElementAt(2).Id}
            //    };
            //    context.PrintingEdition.AddRange(printingeditions);
            //    context.SaveChanges();

            //    var authorsInPrintingEditions = new AuthorInPrintingEditions[]
            //    {
            //        new AuthorInPrintingEditions {AuthorId = authors.First().Id, PrintingEdidtionId = printingeditions.First().Id},
            //        new AuthorInPrintingEditions {AuthorId = authors.ElementAt(1).Id, PrintingEdidtionId = printingeditions.First().Id},
            //        new AuthorInPrintingEditions {AuthorId = authors.ElementAt(3).Id, PrintingEdidtionId = printingeditions.ElementAt(2).Id},
            //        new AuthorInPrintingEditions {AuthorId = authors.ElementAt(2).Id, PrintingEdidtionId = printingeditions.ElementAt(3).Id},
            //        new AuthorInPrintingEditions {AuthorId = authors.ElementAt(5).Id, PrintingEdidtionId = printingeditions.ElementAt(4).Id},
            //        new AuthorInPrintingEditions {AuthorId = authors.ElementAt(4).Id, PrintingEdidtionId = printingeditions.ElementAt(5).Id},
            //    };
            //    context.AuthorInPrintingEditions.AddRange(authorsInPrintingEditions);
            //    context.SaveChanges();
            //    context.Dispose();

            //}

            //public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
            //{
            //    string adminEmail = "admin@gmail.com";
            //    string password = "m055120";
            //    if (await roleManager.FindByNameAsync("admin") == null)
            //    {
            //        await roleManager.CreateAsync(new Role { Name = "admin" });
            //    }
            //    if (await roleManager.FindByNameAsync("user") == null)
            //    {
            //        await roleManager.CreateAsync(new Role { Name = "user" });
            //    }
            //    if (await userManager.FindByNameAsync(adminEmail) == null)
            //    {
            //        User admin = new User { Email = adminEmail, UserName = adminEmail, FirstName = "JO", LastName = "Jo", Password = password, Img = "img" };
            //        IdentityResult result = await userManager.CreateAsync(admin, password);
            //        if (result.Succeeded)
            //        {
            //            await userManager.AddToRoleAsync(admin, "admin");
            //        }
        //}
        }
    }
}
