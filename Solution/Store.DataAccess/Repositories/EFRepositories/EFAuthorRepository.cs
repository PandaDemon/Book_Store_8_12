using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFAuthorRepository : IAuthor
    {
        private DataBaseContext context;
        public EFAuthorRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAllAutor(bool includePtintingEdition = false)
        {
            if (includePtintingEdition)
            {
                return context.Set<Author>().Include(x => x.AuthorInPrintingEditions).AsNoTracking().ToList();
            }
            else
            {
                return context.Author.ToList();
            }
        }

        public Author GetAuthorById(int authorId, bool includePtintingEdition = false)
        {
            if (includePtintingEdition)
            {
                return context.Set<Author>().Include(x => x.AuthorInPrintingEditions).AsNoTracking().FirstOrDefault(x => x.Id == authorId);
            }
            else
            {
                return context.Author.FirstOrDefault(x => x.Id == authorId);
            }
        }

        public void SaveAuthor(Author author)
        {
            if (author.Id == 0)
            {
                context.Author.Add(author);
            }
            else
            {
                context.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAuthor(Author author)
        {
            context.Author.Remove(author);
            context.SaveChanges();
        }
    }
}
