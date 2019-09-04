using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.DrapperRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.EFRepositories
{
    public class UserRepository
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Img { get; set; }

        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
