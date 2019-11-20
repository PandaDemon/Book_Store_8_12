using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task<PrintingEditionViewModel> GetPrintingEditionById(int id);
        Task DeletePrintingEdition(int id);
        Task CreatePrintingEdition(AuthorsInPrintingEditionsViewModel model);
        Task UpdateInformationAboutPrintinEdition(AuthorsInPrintingEditionsViewModel model);        
        Task<IEnumerable<PrintingEditionViewModel>> GetAll();
        AuthorsInPrintingEditionsViewModel GetPrintingEditionByIdInclude(int id);
        IEnumerable<PrintingEditionViewModel> GetAuthorPritningEditions(int id);
    }
}
