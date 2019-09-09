namespace Store.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel
    {
        public string NameEdition { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public int CurrencyId { get; set; }
    }
}
