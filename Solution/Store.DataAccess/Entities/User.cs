﻿using Store.DataAccess.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class User
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

        [ForeignKey("Role")]
        public int RolesId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<UsersInRoles> UsersInRoles { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
