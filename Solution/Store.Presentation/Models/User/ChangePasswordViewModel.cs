﻿namespace Store.Presentation.Models.User
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

        public string OldPassword { get; set; }
    }
}