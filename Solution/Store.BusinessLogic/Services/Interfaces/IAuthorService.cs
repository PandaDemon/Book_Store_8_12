using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthorService
    {
        void Create(AuthorModel model);
        void Update(AuthorModel model);
        void Delete(int id);
        AuthorModel Get(int id);
        IEnumerable<AuthorModel> GetAll();
        IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id);
        IEnumerable<AuthorModel> FilterByName(string filter);
    }
}
