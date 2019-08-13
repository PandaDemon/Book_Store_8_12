using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Models
{
    public class Category
    {
        public int id { set; get; }

        public string categoryName { set; get; }

        public string desc { set; get; }

        public List<PrintingEdition> editions { set; get; }
    }
}
