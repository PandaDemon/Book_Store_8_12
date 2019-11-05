namespace Store.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public double PriceMin { get; set; }
		public double PriceMax { get; set; }
		public string Desc { get; set; }
		public int CategoryId { get; set; }
		public string AvatarUrl { get; set; }
		public int CurrencyId { get; set; }
		public int Quantity { get; set; }

	}
}
