using System;
using System.Collections.Generic;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public double OrderAmount { get; set; }
        public int PrintEditionQuantity { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DatePurchase { get; set; }
        public bool OrderStatus { get; set; }
        public List<AuthorsInPrintingEditionsViewModel> Products { get; set; }

        public OrderViewModel()
        {
            Products = new List<AuthorsInPrintingEditionsViewModel>();
        }
    }
}
