using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<PrintingEdition> PrintingEdition { get; set; }
    }
}
