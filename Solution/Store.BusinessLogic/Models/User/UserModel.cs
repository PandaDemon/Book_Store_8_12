using System.Collections.Generic;

namespace Store.BusinessLogic.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
		public string Password { get; set; }
        public IEnumerable<string> Role { get; set; }
    }
}
