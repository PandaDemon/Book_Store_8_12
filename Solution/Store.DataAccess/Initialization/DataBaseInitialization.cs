using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        public static void Initialize(DataBaseContext content)
        {


            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.PrintingEdition.Any())
            {
                content.AddRange(
                    new PrintingEdition
                    {
                        PrintingEditionName = "Клык",
                        Author = Authors["Тумановский"],
                        Desc = "",
                        Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Death on the Nile",
                        Author = Authors["Kristi"],
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/en/9/96/Death_on_the_Nile_First_Edition_Cover_1937.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Magazine1",
                        Author = Authors["Magazines"],
                        Desc = "",
                        Img = "",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Magazines"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "The Hound of the Baskervilles",
                        Author = Authors["Conan-Doyle"],
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Cover_%28Hound_of_Baskervilles%2C_1902%29.jpg",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        PrintingEditionName = "Newspaper1",
                        Author = Authors["Newspapers"],
                        Desc = "",
                        Img = "",
                        Price = 45,
                        IsInStock = true,
                        Category = Categories["Newspapers"]
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

        private static Dictionary<string, Author> author;
        public static Dictionary<string, Author> Authors
        {
            get
            {
                if (author == null)
                {
                    var list = new Author[]
                    {
                        new Author{FirstName = "Ежи", LastName = "Тумановский"},
                        new Author{FirstName = "Agata", LastName = "Kristi"},
                        new Author{FirstName = "Arthur", LastName = "Conan-Doyle"},
                        new Author{FirstName = "Magazines", LastName = "Magazines"},
                        new Author{FirstName = "Newspapers", LastName = "Newspapers"}
                    };

                    author = new Dictionary<string, Author>();
                    foreach (Author el in list)
                        author.Add(el.LastName, el);
                }
                return author;
            }
        }
    }
}
