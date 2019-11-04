using System.Collections.Generic;

namespace Store.BusinessLogic.Models.Author
{
    public class AuthorsInPrintingEditionsModel
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string PrintingEditionName { get; set; }
        public double PrintingEditionPrice { get; set; }
        public int PrintingEditionCategory { get; set; }
        public string PrintingEditionDescription { get; set; }
        public string PrintingEditionImage { get; set; }
		public IEnumerable<AuthorModel> AuthorList { get; set; }

		public AuthorsInPrintingEditionsModel ()
		{
			AuthorList = new IEnumerable<AuthorModel>();
		}
	}
}
