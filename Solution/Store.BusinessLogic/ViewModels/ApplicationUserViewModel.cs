using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintStore.BusinessLogic.ViewModels
{
    public class ApplicationUserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> RoleName { get; set; }

        public ApplicationUserViewModel()
        {
            RoleName = new List<string>();
        }
    }
}
