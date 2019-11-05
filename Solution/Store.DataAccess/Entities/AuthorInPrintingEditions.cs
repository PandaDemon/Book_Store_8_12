using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class AuthorInPrintingEditions : BaseEntity
    {
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("PrintingEdition")]
        public int PrintingEditionId { get; set; }
        public virtual PrintingEdition PrintingEdition { get; set; }
    }
}
