using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.User
{
    public class UserRecoveryPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
