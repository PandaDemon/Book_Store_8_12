using Store.DataAccess.Entities;
using System;
using System.Linq;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        public static void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;
            }

            var firstUser = new User { FirstName = "Michael", LastName = "Panukov", Password = "m055120", Email = "mpanukov@gmail.com", Img = "https://cdn.mos.cms.futurecdn.net/xMe8cQKSfR3YCSKR6i4sFP-970-80.jpg" };
            var secondUser = new User { FirstName = "Asya", LastName = "Timchenko", Password = "t055120", Email = "Asya@gmail.com", Img = "https://cdn.mos.cms.futurecdn.net/xMe8cQKSfR3YCSKR6i4sFP-970-80.jpg" };
            context.User.AddRange(firstUser, secondUser);
            context.SaveChanges();


            //var firstOrder = new Order { Quantity = 3, UserId = firstUser.Id, OrderDate = DateTime.Now };
            //var secondOrder = new Order { Quantity = 3, UserId = secondUser.Id, OrderDate = DateTime.Now };
            //context.Order.AddRange(firstOrder, secondOrder);
            //context.SaveChanges();


            var roles = new Role[]
            {
                new Role {Name = "admin"},
                new Role {Name = "user"}
             };
            context.Role.AddRange(roles);
            context.SaveChanges();


            var authors = new Author[]
            {
                new Author {LastName = "Тумановский", FirstName = "Ежи" },
                new Author {LastName = "Дядищев ", FirstName = "Александр"},
                new Author {LastName = "Conan-Doyle ", FirstName = "Arthur"},
                new Author {LastName = "Kristi", FirstName = "Agata"},
                new Author{FirstName = "Magazines", LastName = "Magazines"},
                new Author{FirstName = "Newspapers", LastName = "Newspapers"}
            };
            context.Author.AddRange(authors);
            context.SaveChanges();


            //var payments = new Payment[]
            //{
            //    new Payment {PaymentNumber = 876876, IsPaid = true, OrderId = firstOrder.Id},
            //    new Payment {PaymentNumber = 817263, IsPaid = true, OrderId = secondOrder.Id},
            //};
            //context.Payment.AddRange(payments);
            //context.SaveChanges();


            var currency = new Currency[]
            {
                new Currency {Name = "UAN"},
                new Currency {Name = "USD"},
                new Currency {Name = "EUR"}

            };
            context.Currency.AddRange(currency);
            context.SaveChanges();


            var categoty = new Category[]
            {
                new Category { Name = "book"},
                new Category { Name = "magazine"},
                new Category { Name = "newspaper"}
            };
            context.Category.AddRange(categoty);
            context.SaveChanges();


            var printingeditions = new PrintingEdition[]
            {
                new PrintingEdition {Name = "Клык", Desc= "interesting book", Price = 20.3, IsInStock = true, Quantity = 3, CategoryId = categoty.First().Id, Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg", CurrencyId = currency.First().Id },
                new PrintingEdition {Name = "Клык", Desc= "interesting book", Price = 20.3, IsInStock = true, Quantity = 3, CategoryId = categoty.First().Id, Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg", CurrencyId = currency.First().Id },
                new PrintingEdition {Name = "Death on the Nile",  Desc = "interesting book", IsInStock = true, Quantity = 3, Price = 25.5, CategoryId = categoty.First().Id, Img = "https://upload.wikimedia.org/wikipedia/en/9/96/Death_on_the_Nile_First_Edition_Cover_1937.jpg", CurrencyId = currency.ElementAt(1).Id },
                new PrintingEdition {Name = "The Hound of the Baskervilles", Desc = "interesting book", IsInStock = true, Quantity = 3, Price = 2290.3, CategoryId = categoty.First().Id, Img = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Cover_%28Hound_of_Baskervilles%2C_1902%29.jpg",CurrencyId = currency.ElementAt(1).Id },
                new PrintingEdition {Name = "The Times", Desc = "newspaper", Price = 2.30, IsInStock = true, Quantity = 3, CategoryId = categoty.Last().Id, Img = "https://www.historic-newspapers.co.uk/images/newspapers/lrg-newspaper.jpg",CurrencyId = currency.ElementAt(1).Id },
                new PrintingEdition {Name = "Food & Wine", Desc = "interesting magazine", IsInStock = false, Quantity = 3, Price = 5.0, CategoryId = categoty.ElementAt(2).Id, Img = "https://images-na.ssl-images-amazon.com/images/I/61OkFg4sOGL._SY445_.jpg", CurrencyId = currency.ElementAt(2).Id}
            };
            context.PrintingEdition.AddRange(printingeditions);
            context.SaveChanges();


            var authorsInPrintingEditions = new AuthorInPrintingEditions[]
            {
                new AuthorInPrintingEditions {AuthorId = authors.First().Id, PrintingEdidtionId = printingeditions.First().Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(1).Id, PrintingEdidtionId = printingeditions.First().Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(3).Id, PrintingEdidtionId = printingeditions.ElementAt(2).Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(2).Id, PrintingEdidtionId = printingeditions.ElementAt(3).Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(5).Id, PrintingEdidtionId = printingeditions.ElementAt(4).Id},
                new AuthorInPrintingEditions {AuthorId = authors.ElementAt(4).Id, PrintingEdidtionId = printingeditions.ElementAt(5).Id},
            };
            context.AuthorInPrintingEditions.AddRange(authorsInPrintingEditions);
            context.SaveChanges();


            //var usersInRoles = new UserInRole[]
            //{
            //    new UserInRole {UserId = firstUser.Id, RoleId = roles.First().Id},
            //    new UserInRole {UserId = firstUser.Id, RoleId = roles.ElementAt(1).Id}
            //};
            //context.UserInRole.AddRange(usersInRoles);
            //context.SaveChanges();
            //context.Dispose();

        }
    }
}