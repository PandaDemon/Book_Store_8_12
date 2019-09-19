using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class Currency : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Desc { get; set; }
    }
}
