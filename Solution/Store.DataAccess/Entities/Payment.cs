using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentNumber { get; set; }
        public bool IsPaid { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
		[Write(false)]
		public Order Order { get; set; }
    }
}
