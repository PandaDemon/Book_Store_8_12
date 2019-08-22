using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;

namespace Store.BusinessLogic.Services.Implementations
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
    }
}
