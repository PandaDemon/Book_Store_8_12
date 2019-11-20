using PrintStore.DataAccess.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class AuthorsInPrintingEditionsViewModel
    {
        public List<AuthorViewModel> AuthorsList { get; set; }
        [Required]
        public int PrtintingEditionId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        [Required]
        public PrintingEditionType PrtintingEditionType { get; set; }
        [Required]
        public string PrtintingEditionDescription { get; set; }
        [Required]
        public string PrintingEditionTitle { get; set; }
        [Required]
        public double PrintingEditionPrice { get; set; }
        public string PrintingEditionImage { get; set; }
        [Required]
        public PrintingEditionStatus PrintingEditionStatus { get; set; }
        public string AuthorFullName => $"{AuthorFirstName} {AuthorLastName}";
        public string CurrencyName { get; set; }
        public int PrintinEditionQuantityForOrder { get; set; }
        public int CurrencyId { get; set; }

        public AuthorsInPrintingEditionsViewModel()
        {
            AuthorsList = new List<AuthorViewModel>();
        }
    }
}
