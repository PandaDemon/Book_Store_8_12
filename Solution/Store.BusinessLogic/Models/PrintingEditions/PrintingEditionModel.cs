namespace Store.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }
        public string Img { get; set; }
        public int CurrencyId { get; set; }
    }
}
