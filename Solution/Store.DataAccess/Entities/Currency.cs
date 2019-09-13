using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        [Display(Name = "Currency")]
        public string Name { get; set; }
    }
}
