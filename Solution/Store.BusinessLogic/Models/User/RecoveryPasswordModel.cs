using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.User
{
    public class RecoveryPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
