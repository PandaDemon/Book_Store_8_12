using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Store.BusinessLogic.Models.User
{
    class UserChangeRoleModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public List<string> UserRoles { get; set; }
        public UserChangeRoleModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
