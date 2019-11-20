using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;


namespace PrintStore.DataAccess.Entities
{
    [Table ("Currencies")]
    public class Currency
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string CurrencyName { get; set; }
    }
}
