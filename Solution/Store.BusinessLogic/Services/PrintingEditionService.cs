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
        private readonly IPrintingEdition _printingEdition;
        private readonly IAuthor _author;
        private readonly IAuthorInPrintingEdition _authorInPrintingEdition;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEdition printingEdition,
            IAuthor author,
            IAuthorInPrintingEdition authorInPrintingEdition,
            IMapper mapper)
        {
            _printingEdition = printingEdition;
            _author = author;
            _authorInPrintingEdition = authorInPrintingEdition;
            _mapper = mapper;
        }

        public void CreatePrintingEdition(PrintingEditionModel model, AuthorModel authorView)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);
            var author = _mapper.Map<Author>(authorView);
            _printingEdition.Create(printingEdition, author);
        }

        public void DeletePrintingEdition(int id)
        {
            _printingEdition.DeleteAsync(id);
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
            PrintingEdition printingEdition = _printingEdition.Get(id);
            var printingEditionModel = _mapper.Map<PrintingEditionModel>(printingEdition);
            return printingEditionModel;
        }

        public IEnumerable<AuthorModel> GetPritningEditionAuthors(int id)
        {
            PrintingEdition printingEdition = _printingEdition.Get(id);
            var authors = _authorInPrintingEdition.FindByPrintingEdition(printingEdition.Name);
            var model = new List<AuthorModel>();
            foreach (var au in authors)
            {
                Author author = _author.Get(au.AuthorId);
                model.Add(_mapper.Map<AuthorModel>(author));
            };
            return model;
        }

        public void UpdateInformationAboutPrintinEdition(PrintingEditionModel model)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);
            _printingEdition.Update(printingEdition);
        }
    }
}
