using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintStore.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DatePurchase { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [Write(false)]
        public ApplicationUser ApplicationUser { get; set; }
        [Write(false)]
        public Payment Payment { get; set; }
    }
}
