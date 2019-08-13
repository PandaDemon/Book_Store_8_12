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
                    new PrintingEdition
                    {
                        name = "Book1",
                        author = "author1",
                        desc = "",
                        img = "",
                        price = 45,
                        status = true,
                        Category = Categories["Books"]
                    },

                    new PrintingEdition
                    {
                        name = "Magazine1",
                        author = "author1",
                        desc = "",
                        img = "",
                        price = 45,
                        status = true,
                        Category = Categories["Magazines"]
                    },

                    new PrintingEdition
                    {
                        name = "Newspaper1",
                        author = "author2",
                        desc = "",
                        img = "",
                        price = 45,
                        status = true,
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
                        new Category { categoryName = "Books", desc = "Books"},
                        new Category { categoryName = "Magazines", desc = "Magazines"},
                        new Category { categoryName = "Newspapers", desc = "Newspapers"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}
