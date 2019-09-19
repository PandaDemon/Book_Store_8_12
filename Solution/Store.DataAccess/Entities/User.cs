using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class User : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public string AvatarUrl { get; set; }
    }
}
