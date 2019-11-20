using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class UserOrdersViewModel
    {
        [Required]
        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public double OrderAmount { get; set; }
        [Required]
        public bool OrderStatus { get; set; }
        public int PrintEditionQuantity { get; set; }
        public List<PrintingEditionViewModel> Products { get; set; }

        public UserOrdersViewModel()
        {
            Products = new List<PrintingEditionViewModel>();
        }
    }
}
