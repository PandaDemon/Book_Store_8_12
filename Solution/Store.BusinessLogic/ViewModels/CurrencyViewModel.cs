using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class CurrencyViewModel
    {
        [Required]
        public string CurrencyName { get; set; }
        public int Id { get; set; }
    }
}
