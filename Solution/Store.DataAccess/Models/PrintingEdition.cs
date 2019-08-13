using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Models
{
    public class PrintingEdition
    {
        public int id { set; get; }

        public string name { set; get; }

        public string author { set; get; }

        public string desc { set; get; }

        public string img { set; get; }

        public ushort price { set; get; }

        public bool status { set; get; }

        public int categoryID { set; get; }

        public virtual Category Category { set; get; }
    }
}
