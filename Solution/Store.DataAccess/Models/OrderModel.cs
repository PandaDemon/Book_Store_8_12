using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool Stutus { get; set; }

        public int PaymentId { get; set; }

        public virtual PaymentModel Payment { get; set; }

        public int UserId { get; set; }

        public virtual UserModel User { get; set; }

    }
}
