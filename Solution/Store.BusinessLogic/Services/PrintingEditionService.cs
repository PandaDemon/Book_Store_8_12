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
        private readonly IPrintingEditionRepository _printingEdition;
        private readonly IAuthorRepository _author;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEdition;
        private readonly IMapper _mapper;

        public PrintingEditionService(IPrintingEditionRepository printingEdition,
            IAuthorRepository author,
            IAuthorInPrintingEditionRepository authorInPrintingEdition,
            IMapper mapper)
        {
            _printingEdition = printingEdition;
            _author = author;
            _authorInPrintingEdition = authorInPrintingEdition;
            _mapper = mapper;
        }

        public void Create(PrintingEditionModel model, AuthorModel authorView)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PrintingEditionModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrintingEditionModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> GetPritningEditionAuthors(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PrintingEditionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
