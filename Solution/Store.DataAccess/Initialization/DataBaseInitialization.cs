using Store.DataAccess.Entities;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        public void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();

            var authors = new Author[]
            {
                new Author {LastName = "Bulgakov", FirstName = "Mihael" },
                new Author {LastName = "Sapkovskiy", FirstName = "Adjey"},
                new Author {LastName = "Azimov", FirstName = "Ayzek"}
            };
            context.Author.AddRange(authors);
            context.SaveChanges();

            var printingeditions = new PrintingEdition[]
            {
                new PrintingEdition {PrintingEditionName = "Book 1", Desc= "very interesting book", Price = 20.3, CategoryId = 2, Img = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = 2 },
                new PrintingEdition {PrintingEditionName = "Book 2",  Desc = "very interesting book", Price = 25.5, CategoryId = 3, Img = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = 3 },
                new PrintingEdition {PrintingEditionName = "Magazine 1", Desc = "very interesting book", Price = 2290.3, CategoryId = 1, Img = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html",CurrencyId = 1 },
                new PrintingEdition {PrintingEditionName = "Booklet 1",Desc = "very interesting booklet", Price = 10.3, CategoryId = 2, Img = "http://vgorodok.com/promo/3938-russkie-knigi-v-ssha.html", CurrencyId = 2}
            };
            context.PrintingEdition.AddRange(printingeditions);
            context.SaveChanges();


        }
    }
}
