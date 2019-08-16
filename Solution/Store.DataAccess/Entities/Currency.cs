using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string FullCurrencyName { get; set; }

        public ICollection<PrintingEdition> PrintingEditions { get; set; }
    }
}
