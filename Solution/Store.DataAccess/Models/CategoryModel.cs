using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public List<PrintingEditionModel> Editions { get; set; }
    }
}
