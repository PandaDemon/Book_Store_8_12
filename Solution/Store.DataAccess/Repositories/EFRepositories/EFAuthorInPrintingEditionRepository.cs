using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFAuthorInPrintingEditionRepository
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PrintingEdidtionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
    }
}
