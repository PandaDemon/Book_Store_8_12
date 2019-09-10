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
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IPrintingEdition _printingEditionRepository;
        private readonly IAuthor _authorRepository;
        private readonly IAuthorInPrintingEdition _authorInPrintingEditionRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEdition printingEdition,
            IAuthor author,
            IAuthorInPrintingEdition authorInPrintingEdition,
            IMapper mapper)
        {
            _printingEditionRepository = printingEdition;
            _authorRepository = author;
            _authorInPrintingEditionRepository = authorInPrintingEdition;
            _mapper = mapper;
            
        }
        public void CreatePrintingEdition(PrintingEditionModel model, AuthorModel authorView)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);

            var author = _mapper.Map<Author>(authorView);
            _printingEditionRepository.Create(printingEdition, author);
        }

        public void DeletePrintingEdition(int id)
        {
            _printingEditionRepository.DeleteAsync(id);
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByAuthor(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionTitle(string filter)
        {
            throw new NotImplementedException();
        }

        public PrintingEditionModel GetPrintingEditionById(int id)
        {
            PrintingEdition printingEdition = _printingEditionRepository.Get(id);
            var printingEditionModel = _mapper.Map<PrintingEditionModel>(printingEdition);
            return printingEditionModel;
        }

        public IEnumerable<AuthorModel> GetPritningEditionAuthors(int id)
        {
            PrintingEdition printingEdition = _printingEditionRepository.Get(id);
            var authors = _authorInPrintingEditionRepository.FindByPrintingEdition(printingEdition.Name);
            var model = new List<AuthorModel>();
            foreach (var au in authors)
            {
                Author author = _authorRepository.Get(au.AuthorId);
                model.Add(_mapper.Map<AuthorModel>(author));
            };
            return model;
        }


        public void UpdateInformationAboutPrintinEdition(PrintingEditionModel model)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);
            _printingEditionRepository.Update(printingEdition);
        }
    }
}
