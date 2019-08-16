using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public bool IsPaid { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
