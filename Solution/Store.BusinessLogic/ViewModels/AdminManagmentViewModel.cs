using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class AdminManagmentViewModel
    {
        [Required]
        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double OrderAmount { get; set; }
        [Required]
        public bool OrderStatus { get; set; }
        public List<PrintingEditionViewModel> Products { get; set; }

        public AdminManagmentViewModel()
        {
            Products = new List<PrintingEditionViewModel>();
        }
    }
}
