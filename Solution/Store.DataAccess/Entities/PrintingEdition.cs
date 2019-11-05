using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Desc { get; set; }

        public string AvatarUrl { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
		[Write(false)]
		public virtual Category Category { get; set; }

		[ForeignKey("Currency")]
        public int CurrencyId { get; set; }
		[Write(false)]
		public virtual Currency Currency { get; set; }
    }
}