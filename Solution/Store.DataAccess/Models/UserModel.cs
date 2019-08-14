using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public string Img { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        public int RolesId { get; set; }



        public virtual RoleModel Role { get; set; }

        public List<OrderModel> Orders { get; set; }
    }
}
