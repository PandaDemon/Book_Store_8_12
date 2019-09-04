namespace Store.DataAccess.Entities
{
    public class AuthorInPrintingEditions
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PrintingEdidtionId { get; set; }
        public virtual PrintingEdition PrintingEdition { get; set; }
    }
}
