using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditionService
    {
        Task Create(AuthorsInPrintingEditionsModel model);
        void Update(PrintingEditionModel model);
        void Delete(int id);
        Task<PrintingEditionModel> Get(int id);
        IEnumerable<PrintingEditionModel> GetAll();
        Task<IEnumerable<AuthorModel>> GetPritningEditionAuthors(int id);
        
    }
}
