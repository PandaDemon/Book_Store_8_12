using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public bool IsClose { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }


    }
}
