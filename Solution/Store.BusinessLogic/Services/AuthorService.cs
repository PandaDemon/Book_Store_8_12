using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    class AuthorService : IAuthorService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _mapper = mapper;
        }
        public void Create(AuthorModel model)
        {
            var author = _mapper.Map<Author>(model);
            _authorRepository.Create(author);
        }

        public void Update(AuthorModel model)
        {
            var author = _mapper.Map<Author>(model);
            if (_authorRepository.Get(author.Id) != null)
            {
                _authorRepository.Update(author);
            }
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        public IEnumerable<AuthorModel> FilterByName(string firstName, string lastName)
        {
            var listAuthors = _authorRepository.FilterByName(firstName, lastName);

            var model = new List<AuthorModel>();

            foreach (var author in listAuthors)
            {
                model.Add(_mapper.Map<AuthorModel>(author));
            }

            return model;
        }

        public async Task<AuthorModel> Get(int id)
        {
            Author author = await _authorRepository.Get(id);
            var model = _mapper.Map<AuthorModel>(author);
            return model;
        }

        public IEnumerable<AuthorModel> GetAll()
        {
            var authors = _authorRepository.GetAll();
            var model = new List<AuthorModel>();

            foreach (var p in authors)
            {
                model.Add(_mapper.Map<AuthorModel>(p));
            }
            return model;
        }

        public IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id)
        {
            IEnumerable<AuthorInPrintingEditions> printingEditions = _authorInPrintingEditionRepository.FindByAuthor(id);
            var model = new List<PrintingEditionModel>();

            foreach (var printEdition in printingEditions)
            {
                model.Add(_mapper.Map<PrintingEditionModel>(printEdition.PrintingEdition));
            }

            return model;
        }
    }
}
