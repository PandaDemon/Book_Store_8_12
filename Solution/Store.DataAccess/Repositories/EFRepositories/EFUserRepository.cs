using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class EFUserRepository
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
    }
}
