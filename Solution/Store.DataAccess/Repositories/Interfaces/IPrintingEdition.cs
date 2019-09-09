using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEdition
    {
        IEnumerable<PrintingEdition> FilterByAuthor(string authorName);
        IEnumerable<PrintingEdition> FilterByType(string sortOrder);
        IEnumerable<PrintingEdition> FilterByPrice(string sortOrder);
        IEnumerable<PrintingEdition> FilterTitle(string filter);
        IEnumerable<PrintingEdition> GetAll();
        PrintingEdition Get(int id);
        void Create(PrintingEdition item, Author author);
        void Update(PrintingEdition item);
        Task DeleteAsync(int id);
    }
}
