using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFUserInRoleRepository
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
