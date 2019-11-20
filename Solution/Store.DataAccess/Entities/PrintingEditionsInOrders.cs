using System.ComponentModel.DataAnnotations.Schema;

namespace PrintStore.DataAccess.Entities
{
    public class PrintingEditionsInOrders
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("PrintingEdition")]
        public int PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
        public double OrderAmount { get; set; }
        public int PrintEditionQuantity { get; set; }
    }
}
