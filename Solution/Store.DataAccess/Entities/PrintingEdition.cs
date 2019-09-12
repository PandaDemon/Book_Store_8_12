using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Desc { get; set; }

        [Display(Name = "Avatar")]
        public string Img { get; set; }

        [Required]
        public double Price { get; set; }

        public bool IsInStock { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}