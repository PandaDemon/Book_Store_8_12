using System;
using System.ComponentModel.DataAnnotations;

namespace Store.DataAccess.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
    }
}
