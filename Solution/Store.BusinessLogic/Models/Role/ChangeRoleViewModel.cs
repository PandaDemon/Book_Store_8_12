using System.Collections.Generic;

namespace Store.BusinessLogic.Models.Role
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<Store.DataAccess.Entities.Role> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }

        public ChangeRoleViewModel()
        {
            AllRoles = new List<Store.DataAccess.Entities.Role>();
            UserRoles = new List<string>();
        }
    }
}
