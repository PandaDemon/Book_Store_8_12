using Dapper.Contrib.Extensions;
using PrintStore.DataAccess.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintStore.DataAccess.Entities
{
    public class PrintingEdition
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PrintingEditionStatus Status { get; set; }
        public PrintingEditionType Type { get; set; }
        public string NameEdition { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        [Write(false)]
        public Currency Currency { get; set; }
    }
}
