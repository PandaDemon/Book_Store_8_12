﻿namespace Store.BusinessLogic.Models.User
{
    public class UserCreateModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
