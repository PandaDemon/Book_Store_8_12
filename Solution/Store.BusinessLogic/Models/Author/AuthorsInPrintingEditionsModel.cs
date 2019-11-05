using System.Collections.Generic;

namespace Store.BusinessLogic.Models.Author
{
    public class AuthorsInPrintingEditionsModel
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
		public string EditionName { get; set; }
        public double EditionPrice { get; set; }
        public int EditionCategoryId { get; set; }
		public int EditionCurencyId { get; set; }
		public string EditionDesc { get; set; }
        public string EditionAvatarUrl { get; set; }
		public List<AuthorModel> AuthorsList { get; set; }

		public AuthorsInPrintingEditionsModel ()
		{
			AuthorsList = new List<AuthorModel>();
		}
	}
}
