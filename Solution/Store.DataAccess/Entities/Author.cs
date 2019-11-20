using System.ComponentModel.DataAnnotations;

namespace PrintStore.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
    }
}
