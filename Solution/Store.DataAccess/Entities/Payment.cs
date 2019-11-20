using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintStore.DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public bool IsPayed { get; set; }
        public int PaymentNumber { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Write(false)]
        public Order Order { get; set; }
    }
}
