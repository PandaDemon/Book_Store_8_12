using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    class AuthorService : IAuthorService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEdition;
        private readonly IAuthorRepository _author;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IMapper mapper)
        {
            _author = authorRepository;
            _authorInPrintingEdition = authorInPrintingEditionRepository;
            _mapper = mapper;
        }
        public void Create(AuthorModel model)
        {
            var author = _mapper.Map<Author>(model);
            _author.Create(author);
        }

        public void Update(AuthorModel model)
        {
            var author = _mapper.Map<Author>(model);
            if (_author.Get(author.Id) != null)
            {
                _author.Update(author);
            }
        }

        public void Delete(int id)
        {
            _author.Delete(id);
        }

        public IEnumerable<AuthorModel> FilterByName(string filter)
        {
            throw new System.NotImplementedException();
        }

        public AuthorModel Get(int id)
        {
            Author author = _author.Get(id);
            var model = _mapper.Map<AuthorModel>(author);
            return model;
        }

        public IEnumerable<AuthorModel> GetAll()
        {
            var authors = _author.GetAll();
            var model = new List<AuthorModel>();

            foreach (var p in authors)
            {
                model.Add(_mapper.Map<AuthorModel>(p));
            }
            return model;
        }

        public IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id)
        {
            IEnumerable<AuthorInPrintingEditions> printingEditions = _authorInPrintingEdition.FindByAuthor(id);
            var model = new List<PrintingEditionModel>();

            ////List <PrintingEdition> printings = 

            //foreach (var printEdition in printingEditions)
            //{
            //    //model.Add(_mapper.Map<PrintingEditionViewModel>(printEdition.PrintingEdition));

            //}

            return model;
        }
    }
}
