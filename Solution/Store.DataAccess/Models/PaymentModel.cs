using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public List<OrderModel> Orders { get; set; }
    }
}
