using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}
