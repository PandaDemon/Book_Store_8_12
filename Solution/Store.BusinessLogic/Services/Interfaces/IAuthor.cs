using Store.DataAccess.Entities;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services.Interfaces
{
    public interface IAuthor
    {
        IEnumerable<Author> GetAllAutor(bool includePtintingEdition = false);
        Author GetAuthorById(int authorId, bool includePrintingEdition = false);
        void SaveAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
