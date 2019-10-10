using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class PrintStoreService : IPrintStoreService
    {

		private readonly IBaseRepository<PrintingEdition> _printingEditionRepository;
		private readonly IAuthorRepository _authorRepository;
		private readonly IAuthorInPrintingEditionRepository _authorsInPrintingEditionRepository;
		private readonly IMapper _mapper;

		public PrintStoreService(IBaseRepository<PrintingEdition> printingEditionRepository, IAuthorRepository authorRepository, IAuthorInPrintingEditionRepository authorsInPrintingEditionRepository,
		IMapper mapper)
		{
			_authorRepository = authorRepository;
			_authorsInPrintingEditionRepository = authorsInPrintingEditionRepository;
			_printingEditionRepository = printingEditionRepository;
			_mapper = mapper;
		}

		public IEnumerable<AuthorsInPrintingEditionsModel> FilterForPrintingEdition(int categotyId, double filterPrice, string filterName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

		public IEnumerable<PrintingEditionModel> GetAllPrintingEditions()
		{
			var authorsInPrintingEditions = _authorsInPrintingEditionRepository.GetInclude();
			var model = new List<PrintingEditionModel>();
			foreach (var authInPrintingEdition in authorsInPrintingEditions)
			{
				PrintingEdition printingEdition = _printingEditionRepository.Get(authInPrintingEdition.Id);
				model.Add(_mapper.Map<PrintingEditionModel>(printingEdition));
			}
			return model;
		}

        public IEnumerable<PrintingEditionModel> GetAuthorPrintingEditions(string authorName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> SortPrintingEditionByPrice(string sortValue)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<AuthorsInPrintingEditionsModel> GetAllAuthorsInPrintingEditions()
		{
			throw new NotImplementedException();
			//var authorsInPrintingEditions = _authorsInPrintingEditionRepository.GetInclude();

			//IEnumerable<AuthorsInPrintingEditionsModel> model = AuthorsInPrintingEdition(authorsInPrintingEditions);
			//return model;
		}
	}
}
