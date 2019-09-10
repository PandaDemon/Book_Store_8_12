using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        PrintingEditionModel GetPrintingEditionById(int id);
        void DeletePrintingEdition(int id);
        void CreatePrintingEdition(PrintingEditionModel model, AuthorModel authorView);
        void UpdateInformationAboutPrintinEdition(PrintingEditionModel model);
        IEnumerable<AuthorModel> GetPritningEditionAuthors(int id);
        IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionTitle(string filter);
        IEnumerable<AuthorsInPrintingEditionsModel> FilterByAuthor(string filter);
    }
}
