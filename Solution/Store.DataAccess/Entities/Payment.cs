using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Payment number")]
        public int PaymentNumber { get; set; }

        public bool IsPaid { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}