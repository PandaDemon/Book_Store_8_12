
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<PrintingEdition> PrintingEditions { get; set; }
    }
}