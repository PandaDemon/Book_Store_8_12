
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
