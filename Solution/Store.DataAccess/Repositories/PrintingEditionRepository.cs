using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Initialization;
using Store.DataAccess.Models;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DataAccess.Repositories
{
    public class PrintingEditionRepository : IAllEditionsRepository
    {

        private readonly DataBaseInitialization dataBaseInitialization;
        

        public PrintingEditionRepository(DataBaseInitialization dataBaseInitialization)
        {
            this.dataBaseInitialization = dataBaseInitialization;
        }

        public IEnumerable<PrintingEditionModel> PrintingEditions => dataBaseInitialization.PrintingEdition.Include(c => c.Category);

        public PrintingEditionModel getObjectEdition(int EditionId) => dataBaseInitialization.PrintingEdition.FirstOrDefault(p => p.Id == EditionId);
    }
}
