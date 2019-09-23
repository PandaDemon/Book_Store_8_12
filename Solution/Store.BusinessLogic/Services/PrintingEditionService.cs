using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository printingEditionRepository,
            IAuthorRepository authorRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            IMapper mapper)
        {
            _printingEditionRepository = printingEditionRepository;
            _authorRepository = authorRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _mapper = mapper;
        }

        public void Create(PrintingEditionModel model, AuthorModel authorView)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);

            var author = _mapper.Map<Author>(authorView);
            _printingEditionRepository.Create(printingEdition);
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

        public PrintingEditionModel Get(int id)
        {
            PrintingEdition printingEdition = _printingEditionRepository.Get(id);
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

        public IEnumerable<AuthorModel> GetPritningEditionAuthors(int id)
        {
            PrintingEdition printingEdition = _printingEditionRepository.Get(id);
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
