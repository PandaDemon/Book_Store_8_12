using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public bool IsPaid { get; set; }

        public List<Order> Orders { get; set; }
    }
}
