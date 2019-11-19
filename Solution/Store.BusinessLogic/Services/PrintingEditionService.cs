using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
	public class PrintingEditionService : IPrintingEditionService
	{
		private readonly IBaseRepository<PrintingEdition> _printingEditionRepository;
		private readonly IBaseRepository<Author> _authorRepository;
		private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
		private readonly IMapper _mapper;

		public PrintingEditionService(IBaseRepository<PrintingEdition> printingEditionRepository,
			IBaseRepository<Author> authorRepository,
			IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
			IMapper mapper)
		{
			_printingEditionRepository = printingEditionRepository;
			_authorRepository = authorRepository;
			_authorInPrintingEditionRepository = authorInPrintingEditionRepository;
			_mapper = mapper;
		}

		public async Task Create(AuthorsInPrintingEditionsModel model)
		{
			PrintingEdition printingEdition = _mapper.Map<PrintingEdition>(model);

			var authors = new List<Author>();
			var authorsInPrintEdit = new List<AuthorInPrintingEditions>();
			printingEdition.CreateDate = DateTime.UtcNow;
			await _printingEditionRepository.Create(printingEdition);

			foreach (AuthorModel authorId in model.AuthorsList)
			{
				authors.Add(await _authorRepository.Get(authorId.Id));
			}

			foreach (Author author in authors)
			{
				authorsInPrintEdit.Add(new AuthorInPrintingEditions { AuthorId = author.Id, PrintingEditionId = printingEdition.Id });
			}
			_authorInPrintingEditionRepository.AddAuthorInPrintingEdition(authorsInPrintEdit);
			
		}

		public void Update(PrintingEditionModel model)
		{
			var printingEdition = _mapper.Map<PrintingEdition>(model);

			_printingEditionRepository.Update(printingEdition);
		}

		public void Delete(int id)
		{
			_printingEditionRepository.Delete(id);
		}

		public async Task<PrintingEditionModel> Get(int id)
		{
			PrintingEdition printingEdition = await _printingEditionRepository.Get(id);
			var printingEditionModel = _mapper.Map<PrintingEditionModel>(printingEdition);
			return printingEditionModel;
		}

		public IEnumerable<PrintingEditionModel> GetAll()
		{
			var printingEditions = _printingEditionRepository.GetAll();
			var model = new List<PrintingEditionModel>();
			foreach (var printEdition in printingEditions)
			{
				model.Add(_mapper.Map<PrintingEditionModel>(printEdition));
			}
			return model;
		}

		public async Task<IEnumerable<AuthorModel>> GetPritningEditionAuthors(int id)
		{
			PrintingEdition printingEdition = await _printingEditionRepository.Get(id);
			var authors = _authorInPrintingEditionRepository.FindByPrintingEdition(printingEdition.Id);
			var model = new List<AuthorModel>();
			foreach (var author in authors)
			{
				model.Add(_mapper.Map<AuthorModel>(author));
			};
			return model;
		}
	}
}
