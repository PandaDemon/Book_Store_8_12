using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class AuthorViewModel
    {
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
