using AutoMapper;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPrintingEditionRepository _printEditRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, 
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, 
            IPrintingEditionRepository printEditRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _printEditRepository = printEditRepository;
            _mapper = mapper;
        }

        public async Task CreateAuthor(AuthorViewModel model)
        {
            Author author = _mapper.Map<Author>(model);

            await _authorRepository.Create(author);
        }

        public async Task DeleteAuthor(int id)
        {
            await _authorRepository.Delete(id);
        }

        public async Task<IEnumerable<AuthorViewModel>> GetAll()
        {
            IEnumerable<Author> authors = await _authorRepository.GetAll();
            var modelsList = new List<AuthorViewModel>();

            foreach (Author author in authors)
            {
                AuthorViewModel model = _mapper.Map<AuthorViewModel>(author);
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<AuthorViewModel> GetAuthorById(int id)
        {
            Author author = await _authorRepository.Get(id);
            AuthorViewModel model = _mapper.Map<AuthorViewModel>(author);

            return model;
        }     

        public async Task UpdateInformationAboutAuthor(AuthorViewModel model)
        {
            Author authorData = await _authorRepository.Get(model.Id);

            if (authorData != null)
            {
                authorData = _mapper.Map<Author>(model);

                await _authorRepository.Update(authorData);
            }
        }

        public IEnumerable<AuthorViewModel> SortByName(SortOrder sortType, string sortedColumn)
        {
            IEnumerable<Author> authors = _authorRepository.SortByName(sortType, sortedColumn);
            var modelsList = new List<AuthorViewModel>();

            foreach (Author author in authors)
            {
                AuthorViewModel model = _mapper.Map<AuthorViewModel>(author);
                modelsList.Add(model);
            }

            return modelsList;
        }
      

        public IEnumerable<AuthorViewModel> SearchAuthors(string searchString)
        {
            List<AuthorViewModel> modelsList = new List<AuthorViewModel>();
            IEnumerable<Author> authors = _authorRepository.FilterAuthors(searchString);

            foreach (Author author in authors)
            {
                AuthorViewModel model = _mapper.Map<AuthorViewModel>(author);
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<IEnumerable<AuthorViewModel>> GetPritningEditionAuthors(int id)
        {
            PrintingEdition printingEdition = await _printEditRepository.Get(id);
            IEnumerable<AuthorInPrintingEditions> authors = _authorInPrintingEditionRepository.FindByPrintingEditionID(printingEdition.Id);
            var modelsList = new List<AuthorViewModel>();

            foreach (AuthorInPrintingEditions author in authors)
            {
                AuthorViewModel model = _mapper.Map<AuthorViewModel>(author);
                modelsList.Add(model);
            };

            return modelsList;
        }
    }
}
