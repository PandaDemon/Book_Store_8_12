using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task Create(AuthorsInPrintingEditionsModel model/*, AuthorModel authorView*/);
        void Update(PrintingEditionModel model);
        void Delete(int id);
        PrintingEditionModel Get(int id);
        IEnumerable<PrintingEditionModel> GetAll();
        IEnumerable<AuthorModel> GetPritningEditionAuthors(int id);
        
    }
}
