using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFPaymentRepository
    {
        public int Id { get; set; }
        public bool IsPayed { get; set; }
        public int PaymentNumber { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
