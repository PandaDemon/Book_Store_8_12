using System.ComponentModel.DataAnnotations;
namespace PrintStore.BusinessLogic.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
