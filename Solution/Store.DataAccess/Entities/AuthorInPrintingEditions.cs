using System.ComponentModel.DataAnnotations.Schema;

namespace PrintStore.DataAccess.Entities
{
    public class AuthorInPrintingEditions
    {
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [ForeignKey("PrintingEdition")]
        public int PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
    }
}
