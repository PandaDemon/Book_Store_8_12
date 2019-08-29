using System.ComponentModel.DataAnnotations;

namespace Store.Presentation.Models.User
{
    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "Логин")]
        //public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember? ")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
