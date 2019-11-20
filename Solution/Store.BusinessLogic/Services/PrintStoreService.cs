using AutoMapper;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;
using PrintStore.DataAccess.Entities.Enums;
using PrintStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.BusinessLogic.Services
{
    public class PrintStoreService : IPrintStoreService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyConverter _currencyConverter;
        private readonly IMapper _mapper;

        public PrintStoreService(IAuthorRepository authorRepository,
            IAuthorInPrintingEditionRepository authorInPrintingEditionRepository,
            IPrintingEditionRepository printingEditionRepository,
            ICurrencyRepository currencyRepository,
            ICurrencyConverter currencyConverter,
            IMapper mapper)
        {
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _authorRepository = authorRepository;
            _printingEditionRepository = printingEditionRepository;
            _currencyRepository = currencyRepository;
            _currencyConverter = currencyConverter;
            _mapper = mapper;
        }
       
        public IEnumerable<AuthorsInPrintingEditionsViewModel> SortAndFilterData(SortOrder sortOrder, string currentCurrencyName, 
            string column, int firstElement, int lastElement, string filter, PrintingEditionType type, PrintingEditionStatus status)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository
                .SortAndFilterData(sortOrder, column, firstElement, lastElement, filter, type, status);
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = AuthorsInPrintForming(authorsInPriningEditions, currentCurrencyName);
            
            return modelsList;
        }        

        public async Task<IEnumerable<PrintingEditionViewModel>> GetAllPrintingEditions()
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.GetWithInclude();
            var modelsList = new List<PrintingEditionViewModel>();

            foreach (AuthorInPrintingEditions authInPrintingEdition in authorsInPriningEditions)
            {
                PrintingEdition printingEdition = await _printingEditionRepository.Get(authInPrintingEdition.PrintingEditionId);
                modelsList.Add(_mapper.Map<PrintingEditionViewModel>(printingEdition));
            }

            return modelsList;
        }

        public async Task<IEnumerable<PrintingEditionViewModel>> GetAuthorPrintingEditions(int authorId, string currentCurrencyName)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.FindByAuthor(authorId);
            var modelsList = new List<PrintingEditionViewModel>();

            foreach (AuthorInPrintingEditions authInPrintingEdition in authorsInPriningEditions)
            {
                PrintingEdition printingEdition = await _printingEditionRepository.Get(authInPrintingEdition.PrintingEditionId);
                modelsList.Add(_mapper.Map<PrintingEditionViewModel>(printingEdition));
            };

            return modelsList;
        }               
      
        public AuthorsInPrintingEditionsViewModel GetPrintingEditionByIdInclude(int id, string currentCurrencyName)
        {
            IEnumerable<AuthorInPrintingEditions> modelFromBase = _authorInPrintingEditionRepository.FindByPrintingEditionID(id);
            AuthorsInPrintingEditionsViewModel authInPEmodel = AuthorsInPrintForming(modelFromBase, currentCurrencyName)
                .First(model => model.PrtintingEditionId == id);

            return authInPEmodel;
        }

        public IEnumerable<AuthorViewModel> SearchAuthors(string searchString, string currentCurrencyName)
        {
            List<AuthorViewModel> modelsList = new List<AuthorViewModel>();
            IEnumerable<Author> authors = _authorRepository.FilterAuthors(searchString);

            foreach (Author author in authors)
            {
                modelsList.Add(_mapper.Map<AuthorViewModel>(author));
            }

            return modelsList;
        }

        public IEnumerable<AuthorsInPrintingEditionsViewModel> SortPriceInRange(int sortPriceFrom, int sortPriceTo, string currentCurrencyName, int firstElement, int lastElement)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.SortPriceInRange(sortPriceFrom, sortPriceTo, firstElement, lastElement);
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = AuthorsInPrintForming(authorsInPriningEditions, currentCurrencyName);

            return modelsList;
        }

        public async Task<IEnumerable<CurrencyViewModel>> GetCurrencies()
        {
            IEnumerable<Currency> currencies = await _currencyRepository.GetAll();
            var modelsList = new List<CurrencyViewModel>();

            foreach (Currency currecy in currencies)
            {
                modelsList.Add(_mapper.Map<CurrencyViewModel>(currecy));
            }

            return modelsList;
        }
    
        public IEnumerable<AuthorsInPrintingEditionsViewModel> GetAllWithCurrencyConvert(string currencyName, int firstElement, int lastElement)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.GetWithInclude();
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = AuthorsInPrintForming(authorsInPriningEditions, currencyName);

            return modelsList;
        }

        public IEnumerable<AuthorsInPrintingEditionsViewModel> GetAuthorsInPrintingEditionsPage(int firstElementId, int lastElementId, string currentCurrencyName)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.GetAuthorsInPrintingEditionsPage(firstElementId, lastElementId);
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = AuthorsInPrintForming(authorsInPriningEditions, currentCurrencyName);

            return modelsList;
        }

        public async Task<int> GetCountOfEditionsInStoreAsync()
        {
            int count = await _authorInPrintingEditionRepository.GetCountOfEditionsInStoreAsync();

            return count;
        }

        public IEnumerable<AuthorsInPrintingEditionsViewModel> FilterData(string filter, string currentCurrencyName, int firstElement, int lastElement, string column)
        {
            IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions = _authorInPrintingEditionRepository.FilterData(filter, column, firstElement, lastElement);
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = AuthorsInPrintForming(authorsInPriningEditions, currentCurrencyName);

            return modelsList;
        }

        private IEnumerable<AuthorsInPrintingEditionsViewModel> AuthorsInPrintForming(IEnumerable<AuthorInPrintingEditions> authorsInPriningEditions, string currentCurrencyName)
        {
            var modelsList = new List<AuthorsInPrintingEditionsViewModel>();

            foreach (AuthorInPrintingEditions printEd in authorsInPriningEditions)
            {
                AuthorsInPrintingEditionsViewModel printEditionModel = modelsList.FirstOrDefault(r => r.PrtintingEditionId == printEd.PrintingEditionId);

                if (printEditionModel == null)
                {
                    double price = _currencyConverter.Convert(printEd.PrintingEdition.Currency, printEd.PrintingEdition.Price, currentCurrencyName);
                    printEditionModel = new AuthorsInPrintingEditionsViewModel
                    {
                        CurrencyName = currentCurrencyName,
                        PrintingEditionImage = printEd.PrintingEdition.ImageUrl,
                        PrintingEditionStatus = printEd.PrintingEdition.Status,
                        PrintingEditionPrice = price,
                        PrintingEditionTitle = printEd.PrintingEdition.NameEdition,
                        PrtintingEditionDescription = printEd.PrintingEdition.Description,
                        PrtintingEditionType = printEd.PrintingEdition.Type,
                        PrtintingEditionId = printEd.PrintingEditionId
                    };

                    modelsList.Add(printEditionModel);
                }

                printEditionModel.AuthorsList.Add(new AuthorViewModel
                {
                    FirstName = printEd.Author.FirstName,
                    LastName = printEd.Author.LastName,
                    Id = printEd.Author.Id
                });
            }

            return modelsList;
        }
    }
}
