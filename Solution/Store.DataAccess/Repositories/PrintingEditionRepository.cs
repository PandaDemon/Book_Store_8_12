using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Store.DataAccess.Repositories
{
    public class PrintingEditionRepository : IAllEditionsRepository
    {
        private readonly DataBaseContext dataBaseInitialization;

        public PrintingEditionRepository(DataBaseContext dataBaseInitialization)
        {
            this.dataBaseInitialization = dataBaseInitialization;
        }

        public IEnumerable<PrintingEdition> PrintingEditions => dataBaseInitialization.PrintingEdition.Include(c => c.Category);

        public PrintingEdition getObjectEdition(int EditionId) => dataBaseInitialization.PrintingEdition.FirstOrDefault(p => p.Id == EditionId);

    }
}