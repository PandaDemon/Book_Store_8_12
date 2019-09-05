using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.BusinessLogic.Models
{
    public class RegistrationData
    {
        [Display(Description = "Record #")]
        public int Id { get; set; }

        [Display(Description = "Username")]
        public string UserName { get; set; }

        [Required, RegularExpression(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})", ErrorMessage = "Please enter a valid email address.")]
        [EmailAddress]
        [Display(Description = "Email Address", Name = "EmailAddress", ShortName = "Email", Prompt = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Description = "Password", Name = "Password")]
        public string Password { get; set; }
    }
}
