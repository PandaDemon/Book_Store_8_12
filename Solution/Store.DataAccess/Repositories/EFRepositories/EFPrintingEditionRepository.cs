using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFPrintingEditionRepository : IPrintingEdition
    {
        private DataBaseContext context;
        public EFPrintingEditionRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<PrintingEdition> GetAllPrintingEdition(bool includeCategory = false)
        {
            if (includeCategory)
            {
                return context.Set<PrintingEdition>().Include(x => x.AuthorInPrintingEditions).AsNoTracking().ToList();
            }

            else
            {
                return context.PrintingEdition.ToList();
            }
        }

        public PrintingEdition GetPrintingEditionById(int printingEditionId, bool includeCategory = false)
        {
            if (includeCategory)
            {
                return context.Set<PrintingEdition>().Include(x => x.AuthorInPrintingEditions).AsNoTracking().FirstOrDefault(x => x.Id == printingEditionId);
            }
            else
            {
                return context.PrintingEdition.FirstOrDefault(x => x.Id == printingEditionId);
            }
        }

        public void SavePrintingEdition(PrintingEdition printingEdition)
        {
            if (printingEdition.Id == 0)
            {
                context.PrintingEdition.Add(printingEdition);
            }
            else
            {
                context.Entry(printingEdition).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletePrintingEdition(PrintingEdition printingEdition)
        {
            context.PrintingEdition.Remove(printingEdition);
            context.SaveChanges();
        }
        public void DeleteAuthor(Author author)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Author> GetAllAutor(bool includePtintingEdition = false)
        {
            throw new System.NotImplementedException();
        }

        public Author GetAuthorById(int authorId, bool includePrintingEdition = false)
        {
            throw new System.NotImplementedException();
        }

        public void SaveAuthor(Author author)
        {
            throw new System.NotImplementedException();
        }
    }
}
