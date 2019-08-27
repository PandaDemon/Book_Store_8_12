﻿using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.User
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
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
