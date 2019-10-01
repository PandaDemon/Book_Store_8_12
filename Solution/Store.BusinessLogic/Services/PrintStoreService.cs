using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class PrintStoreService : IPrintStoreService
    {
        public IEnumerable<AuthorsInPrintingEditionsModel> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> GetAllAuthorsInPrintingEditions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingEditionModel> GetAllPrintingEditions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingEditionModel> GetAuthorPrintingEditions(string authorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> SortPrintingEditionByPrice(string sortValue)
        {
            throw new NotImplementedException();
        }
    }
}
