using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Models
{
    public class PrintingEditionModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public virtual AuthorModel Author { get; set; }

        public string Desc { get; set; }

        public string Img { get; set; }

        [Required]
        public ushort Price { get; set; }

        public bool Status { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }
    }
}
