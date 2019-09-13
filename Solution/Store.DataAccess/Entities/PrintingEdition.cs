﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string Desc { get; set; }

        public string AvatarUrl { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}