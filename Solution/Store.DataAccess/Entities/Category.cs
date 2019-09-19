using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}
