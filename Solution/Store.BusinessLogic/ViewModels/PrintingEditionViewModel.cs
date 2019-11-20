using PrintStore.DataAccess.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class PrintingEditionViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public PrintingEditionStatus Status { get; set; }
        [Required]
        public PrintingEditionType Type { get; set; }
        [Required]
        public string NameEdition { get; set; }
        public string Image { get; set; }
        [Required]
        public double Price { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
    }
}
