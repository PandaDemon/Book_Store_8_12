using Store.DataAccess.Entities;
using Store.DataAccess.Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        public static void Initialize(DataBaseContext content)
        {


            //if (!content.Category.Any())
            //{
            //    content.Category.AddRange(Categories.Select(c => c.Value));
            //}

            if (!content.PrintingEdition.Any())
            {
                content.AddRange(
                    new PrintingEdition
                    {
                        PrintingEditionName = "Клык",
                        Desc = "",
                        Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Death on the Nile",
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/en/9/96/Death_on_the_Nile_First_Edition_Cover_1937.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Magazine1",
                        Desc = "",
                        Img = "",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Magazines"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "The Hound of the Baskervilles",
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Cover_%28Hound_of_Baskervilles%2C_1902%29.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Newspaper1",
                        Desc = "",
                        Img = "",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Newspapers"]
                    }
                );

            }

            content.SaveChanges();

            if (!content.AuthorInPrintingEditions.Any())
            {
                content.AddRange(
                    new AuthorInPrintingEditions
                    {
                        AuthorId = 1,
                        PrintingEdidtionId = 2
                    },

                    new AuthorInPrintingEditions
                    {
                        AuthorId = 2,
                        PrintingEdidtionId = 3
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Books"},
                        new Category { CategoryName = "Magazines"},
                        new Category { CategoryName = "Newspapers"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }

                return category;
            }
        }

        //private static Dictionary<string, Author> author;
        //public static Dictionary<string, Author> Authors
        //{
        //    get
        //    {
        //        if (author == null)
        //        {
        //            var list = new Author[]
        //            {
        //                new Author{FirstName = "Ежи", LastName = "Тумановский"},
        //                new Author{FirstName = "Agata", LastName = "Kristi"},
        //                new Author{FirstName = "Arthur", LastName = "Conan-Doyle"},
        //                new Author{FirstName = "Magazines", LastName = "Magazines"},
        //                new Author{FirstName = "Newspapers", LastName = "Newspapers"}
        //            };

        //            author = new Dictionary<string, Author>();
        //            foreach (Author el in list)
        //                author.Add(el.LastName, el);
        //        }
        //        return author;
        //    }
        //}

        private static Dictionary<string, Currency> currency;
        public static Dictionary<string, Currency> Currency
        {
            get
            {
                if (currency == null)
                {
                    var list = new Currency[]
                    {
                        new Currency{FullCurrencyName = "UAN" },
                        new Currency{FullCurrencyName = "RUB" },
                        new Currency{FullCurrencyName = "USD" }
                    };

                    currency = new Dictionary<string, Currency>();
                    foreach (Currency el in list)
                        currency.Add(el.FullCurrencyName, el);
                }
                return currency;
            }
        }
    }
}
