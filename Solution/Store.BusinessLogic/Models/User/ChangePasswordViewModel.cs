﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.BusinessLogic.Models.User
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

        public string OldPassword { get; set; }
    }
}
