using Microsoft.AspNetCore.Mvc;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities.Enums;
using Store.Presentation.Controllers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PrintStore.Presentation.Controllers
{
    public class PrintingStoreController : BaseApiController
    {
        private readonly IPrintStoreService _printStoreService;
        private readonly IOrderService _orderService;
        private readonly IAuthorService _authorService;
        private readonly IPrintingEditionService _printingEditionService;

        public PrintingStoreController(IPrintStoreService printStoreService, IPrintingEditionService printingEditionService, IAuthorService authorService, IOrderService orderService)
        {
            _orderService = orderService;
            _printStoreService = printStoreService;
            _printingEditionService = printingEditionService;
            _authorService = authorService;
        }

        [HttpGet("GetAuthorsInPrintingEditionsPage")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> GetAuthorsInPrintingEditionsPage(SortOrder order, int firstElement, int lastElement,
            string currentCurrencyName, string filter, string column, PrintingEditionStatus status, PrintingEditionType type)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList =
                _printStoreService.SortAndFilterData(order, currentCurrencyName, column, firstElement, lastElement, filter, type, status);

            return modelsList;
        }

        [HttpGet("FilterByAll")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> FilterByAll(string filter, string currentCurrencyName, int firstElement, int lastElement, string column)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList =
                _printStoreService.FilterData(filter, currentCurrencyName, firstElement, lastElement, column);

            return modelsList;
        }

        [HttpGet("GetCountOfEditionsInStore")]
        public async Task<int> GetCountOfEditionsInStore()
        {
            int count = await _printStoreService.GetCountOfEditionsInStoreAsync();

            return count;
        }

        [HttpPost("CreateNewOrder")]
        public async Task<int> CreateNewOrder([FromBody]OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            int orderId = await _orderService.CreateOrder(model);

            return orderId;
        }

        [HttpGet("GetCurrencies")]
        public async Task<IEnumerable<CurrencyViewModel>> GetCurrencies()
        {
            IEnumerable<CurrencyViewModel> modelsList = await _printStoreService.GetCurrencies();

            return modelsList;
        }

        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _orderService.CreatePayment(model);

            return Ok(201);
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IEnumerable<AuthorViewModel>> GetAllAuthors()
        {
            IEnumerable<AuthorViewModel> modelsList = await _authorService.GetAll();

            return modelsList;
        }

        [HttpGet(("GetSortedAuthorsByName"))]
        public IEnumerable<AuthorViewModel> GetSortedAuthorsName(SortOrder order, string column)
        {
            IEnumerable<AuthorViewModel> modelsList = _authorService.SortByName(order, column);

            return modelsList;
        }

        [HttpGet("GetFilteredAuthors")]
        public IEnumerable<AuthorViewModel> GetFilteredAuthors(string filter)
        {
            IEnumerable<AuthorViewModel> modelsList = _authorService.SearchAuthors(filter);

            return modelsList;
        }

        [HttpGet("GetAuthor")]
        public async Task<AuthorViewModel> GetAuthor(int id)
        {
            AuthorViewModel modelsList = await _authorService.GetAuthorById(id);

            return modelsList;
        }

        [HttpGet("GetPrintingEdition")]
        public AuthorsInPrintingEditionsViewModel GetPrintingEdition(int id, string currentCurrencyName)
        {
            AuthorsInPrintingEditionsViewModel modelsList = _printStoreService.GetPrintingEditionByIdInclude(id, currentCurrencyName);

            return modelsList;
        }

        [HttpGet("GetSortedPriceInRange")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> GetSortedPriceInRange(int sortPriceFrom, int sortPriceTo, string currentCurrencyName, int firstElement, int lastElement)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = _printStoreService.SortPriceInRange(sortPriceFrom, sortPriceTo, currentCurrencyName, firstElement, lastElement);

            return modelsList;
        }

        [HttpGet("FilterByAuthors")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> FilterByAuthors(string filter, string currentCurrencyName, int firstElement, int lastElement, string column)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = _printStoreService.FilterData(filter, currentCurrencyName, firstElement, lastElement, column);

            return modelsList;
        }

        [HttpGet("SearchAuthorsForAuthrTable")]
        public IEnumerable<AuthorViewModel> SearchAuthorsForAuthrTable(string filter, string currentCurrencyName)
        {
            IEnumerable<AuthorViewModel> modelsList = _printStoreService.SearchAuthors(filter, currentCurrencyName);

            return modelsList;
        }

        [HttpGet("FilterByPrintingEditionTitle")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> FilterByPrintingEditionTitle(string filter, string currentCurrencyName, int firstElement, int lastElement, string column)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = _printStoreService.FilterData(filter, currentCurrencyName, firstElement, lastElement, column);

            return modelsList;
        }

        [HttpGet("FilterByPrintingEditionDescription")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> FilterByPrintingEditionDescription(string filter, string currentCurrencyName, int firstElement, int lastElement, string column)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = _printStoreService.FilterData(filter, currentCurrencyName, firstElement, lastElement, column);

            return modelsList;
        }

        [HttpGet("GetAllPrintingEditions")]
        public async Task<IEnumerable<PrintingEditionViewModel>> GetAllPrintingEditions()
        {
            IEnumerable<PrintingEditionViewModel> modelsList = await _printingEditionService.GetAll();

            return modelsList;
        }

        [HttpGet("GetAuthorPrintingEditions")]
        public async Task<IEnumerable<PrintingEditionViewModel>> GetAuthorPrintingEditions(int authorId, string currentCurrencyName)
        {
            IEnumerable<PrintingEditionViewModel> modelsList = await _printStoreService.GetAuthorPrintingEditions(authorId, currentCurrencyName);

            return modelsList;
        }

        [HttpGet("GetPritningEditionAuthors")]
        public async Task<IEnumerable<AuthorViewModel>> GetPritningEditionAuthors(int id)
        {
            IEnumerable<AuthorViewModel> modelsList = await _authorService.GetPritningEditionAuthors(id);

            return modelsList;
        }

        [HttpGet("GetAllWithCurrencyConvert")]
        public IEnumerable<AuthorsInPrintingEditionsViewModel> GetAllWithCurrencyConvert(string currencyName, int firstElement, int lastElement)
        {
            IEnumerable<AuthorsInPrintingEditionsViewModel> modelsList = _printStoreService.GetAllWithCurrencyConvert(currencyName, firstElement, lastElement);

            return modelsList;
        }
    }
}
