using AutoMapper;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services
{
    public class PrintingEditionService : IPrintingEditionService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IPrintingEditionRepository _printEditRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public PrintingEditionService(IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            IAuthorRepository authorRepository,
            IPrintingEditionRepository printEditRepository,
            IMapper mapper)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _mapper = mapper;
            _printEditRepository = printEditRepository;
            _authorRepository = authorRepository;
        }

        public async Task CreatePrintingEdition(AuthorsInPrintingEditionsViewModel model)
        {
            PrintingEdition printingEdition = _mapper.Map<PrintingEdition>(model);
            var authors = new List<Author>();
            var authorsInPrintEdit = new List<AuthorInPrintingEditions>();

            await _printEditRepository.Create(printingEdition);

            foreach (AuthorViewModel authorId in model.AuthorsList)
            {
                authors.Add(await _authorRepository.Get(authorId.Id));
            }                     

            foreach (Author author in authors)
            {
                authorsInPrintEdit.Add(new AuthorInPrintingEditions { AuthorId = author.Id, PrintingEditionId = printingEdition.Id });
            }

            _authorInPrintingEditionRepository.AddAuthorInPe(authorsInPrintEdit);
        }

        public async Task DeletePrintingEdition(int id)
        {
            await _printEditRepository.Delete(id);
        }

        public async Task<IEnumerable<PrintingEditionViewModel>> GetAll()
        {
            IEnumerable<PrintingEdition> printingEditions = await _printEditRepository.GetAll();
            var modelsList = new List<PrintingEditionViewModel>();

            foreach (PrintingEdition printEdition in printingEditions)
            {
                PrintingEditionViewModel model = _mapper.Map<PrintingEditionViewModel>(printEdition);
                modelsList.Add(model);
            }

            return modelsList;
        }

        public async Task<PrintingEditionViewModel> GetPrintingEditionById(int id)
        {
            PrintingEdition printingEdition = await _printEditRepository.Get(id);
            PrintingEditionViewModel printingEditionModel = _mapper.Map<PrintingEditionViewModel>(printingEdition);

            return printingEditionModel;
        }

        public AuthorsInPrintingEditionsViewModel GetPrintingEditionByIdInclude(int id)
        {
            IEnumerable<AuthorInPrintingEditions> modelFromBase = _authorInPrintingEditionRepository.FindByPrintingEditionID(id);
            AuthorsInPrintingEditionsViewModel model = _mapper.Map<AuthorsInPrintingEditionsViewModel>(modelFromBase);

            return model;
        }        

        public async Task UpdateInformationAboutPrintinEdition(AuthorsInPrintingEditionsViewModel model)
        {
            var printingEdition = _mapper.Map<PrintingEdition>(model);
            var printEditionFromBase = await _printEditRepository.Get(model.PrtintingEditionId);
            var authors = new List<Author>();

            if (printEditionFromBase is null)
            {
                return;
            }

            printEditionFromBase = _mapper.Map<PrintingEdition>(model);

            await _printEditRepository.Update(printEditionFromBase);

            foreach (AuthorViewModel author in model.AuthorsList)
            {
                authors.Add(await _authorRepository.Get(author.Id));
            }

            IEnumerable<AuthorInPrintingEditions> authorInPrintEdBase = _authorInPrintingEditionRepository.FindByPrintingEditionID(printEditionFromBase.Id);

            _authorInPrintingEditionRepository.DeleteAuthorInPe(authorInPrintEdBase);

            var authorInPrintingEditionsNew = new List<AuthorInPrintingEditions>();

            foreach (Author author in authors)
            {
                authorInPrintingEditionsNew.Add(new AuthorInPrintingEditions
                {
                    AuthorId = author.Id,
                    PrintingEditionId = printingEdition.Id
                });
            }

            _authorInPrintingEditionRepository.AddAuthorInPe(authorInPrintingEditionsNew);
        }

        public IEnumerable<PrintingEditionViewModel> GetAuthorPritningEditions(int id)
        {
            IEnumerable<AuthorInPrintingEditions> printingEditions = _authorInPrintingEditionRepository.FindByAuthor(id);
            var modelsList = new List<PrintingEditionViewModel>();

            foreach (AuthorInPrintingEditions printEdition in printingEditions)
            {
                modelsList.Add(_mapper.Map<PrintingEditionViewModel>(printEdition.PrintingEdition));
            }

            return modelsList;
        }
    }
}
