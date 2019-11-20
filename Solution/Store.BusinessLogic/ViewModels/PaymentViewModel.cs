namespace PrintStore.BusinessLogic.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public bool IsPayed { get; set; }
        public int PaymentNumber { get; set; }
        public int OrderId { get; set; }
    }
}
