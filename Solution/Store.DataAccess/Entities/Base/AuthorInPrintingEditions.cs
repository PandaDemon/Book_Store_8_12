using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.DataAccess.Entities.Base
{
    public class AuthorInPrintingEditions
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PrintingEdidtionId { get; set; }
        public virtual PrintingEdition PrintingEdition { get; set; }
    }
}
