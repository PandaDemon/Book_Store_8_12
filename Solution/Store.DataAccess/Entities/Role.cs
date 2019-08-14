﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
