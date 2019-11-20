using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> GetAuthorById(int id);
        Task<IEnumerable<AuthorViewModel>> GetAll();
        Task DeleteAuthor(int id);
        Task CreateAuthor(AuthorViewModel model);
        Task UpdateInformationAboutAuthor(AuthorViewModel model);
        Task<IEnumerable<AuthorViewModel>> GetPritningEditionAuthors(int id);
        IEnumerable<AuthorViewModel> SortByName(SortOrder sortType, string sortedColumn);
        IEnumerable<AuthorViewModel> SearchAuthors(string searchString);
    }
}
