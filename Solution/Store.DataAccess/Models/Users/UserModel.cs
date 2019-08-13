using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Models.Users
{
    public class UserModel
    {
        public int UserId { set; get; }

        public string User { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

    }
}
