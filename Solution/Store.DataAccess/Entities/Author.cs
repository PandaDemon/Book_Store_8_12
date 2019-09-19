using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}