using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentNumber { get; set; }
        public bool IsPaid { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
