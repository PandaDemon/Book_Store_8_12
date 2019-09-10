using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        AuthorModel GetAuthorById(int id);
        void DeleteAuthor(int id);
        void CreateAuthor(AuthorModel model);
        void UpdateInformationAboutAuthor(AuthorModel model);
        IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id);
        IEnumerable<AuthorModel> SortByFirstName(string order);
        IEnumerable<AuthorModel> SortByLastName(string order);
        IEnumerable<AuthorModel> FilterAuthor(string filter);
    }
}
