using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Initialization
{
    public class DBObjects
    {
        public static void Initial(DataBaseInitialization content)
        {


            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.PrintingEdition.Any())
            {
                content.AddRange(
                    new PrintingEditionModel
                    {
                        Name = "Клык",
                        Author = Authors["Тумановский"],
                        Desc = "",
                        Img = "http://testlib.meta.ua/image/266/265964/dbdfd22a03.jpg",
                        Price = 45,
                        Status = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEditionModel
                    {
                        Name = "Death on the Nile",
                        Author = Authors["Kristi"],
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/en/9/96/Death_on_the_Nile_First_Edition_Cover_1937.jpg",
                        Price = 45,
                        Status = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEditionModel
                    {
                        Name = "Magazine1",
                        Author = Authors["Magazines"],
                        Desc = "",
                        Img = "",
                        Price = 45,
                        Status = true,
                        Category = Categories["Magazines"]
                    },

                    new PrintingEditionModel
                    {
                        Name = "The Hound of the Baskervilles",
                        Author = Authors["Conan-Doyle"],
                        Desc = "",
                        Img = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Cover_%28Hound_of_Baskervilles%2C_1902%29.jpg",
                        Price = 45,
                        Status = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEditionModel
                    {
                        Name = "Newspaper1",
                        Author = Authors["Newspapers"],
                        Desc = "",
                        Img = "",
                        Price = 45,
                        Status = true,
                        Category = Categories["Newspapers"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, CategoryModel> category;
        public static Dictionary<string, CategoryModel> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new CategoryModel[]
                    {
                        new CategoryModel { CategoryName = "Books"},
                        new CategoryModel { CategoryName = "Magazines"},
                        new CategoryModel { CategoryName = "Newspapers"}
                    };

                    category = new Dictionary<string, CategoryModel>();
                    foreach (CategoryModel el in list)
                        category.Add(el.CategoryName, el);
                }

                return category;
            }
        }

        private static Dictionary<string, AuthorModel> author;
        public static Dictionary<string, AuthorModel> Authors
        {
            get
            {
                if (author == null)
                {
                    var list = new AuthorModel[]
                    {
                        new AuthorModel{FirstName = "Ежи", LastName = "Тумановский"},
                        new AuthorModel{FirstName = "Agata", LastName = "Kristi"},
                        new AuthorModel{FirstName = "Arthur", LastName = "Conan-Doyle"},
                        new AuthorModel{FirstName = "Magazines", LastName = "Magazines"},
                        new AuthorModel{FirstName = "Newspapers", LastName = "Newspapers"}
                    };

                    author = new Dictionary<string, AuthorModel>();
                    foreach (AuthorModel el in list)
                        author.Add(el.LastName, el);
                }
                return author;
            }
        }
    }
}
