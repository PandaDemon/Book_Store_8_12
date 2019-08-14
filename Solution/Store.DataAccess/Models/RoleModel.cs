using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.DataAccess.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public List<UserModel> Users { get; set; }
    }
}
