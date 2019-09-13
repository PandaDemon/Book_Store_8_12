using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFOrderRepository
    {
        public int Id { get; set; }
        public DateTime DatePurchase { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
