using Microsoft.AspNetCore.Mvc;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IAuthorService _authorService;
        private readonly IPrintingEditionService _printingEditionService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IAdminService _adminService;

        public AdminController(IAuthorService authorService,
            IPrintingEditionService printingEditionService,
            IAdminService adminService,
            IApplicationUserService applicationUserService)
        {
            _authorService = authorService;
            _printingEditionService = printingEditionService;
            _applicationUserService = applicationUserService;
            _adminService = adminService;
        }

        [HttpGet("GetAllUsersProfile")]
        public async Task<object> GetAllUsersProfile()
        {
            IEnumerable<ApplicationUserViewModel> users = await _applicationUserService.GetAllAsync();

            return users;
        }

        [HttpGet("GetAllUsersOrder")]
        public IEnumerable<AdminManagmentViewModel> GetAllUsersOrder()
        {
            IEnumerable<AdminManagmentViewModel> allorders = _adminService.GetAllUsersOrder();

            return allorders;
        }

        [HttpGet("OrderTimeSort")]
        public IEnumerable<AdminManagmentViewModel> OrderSort(SortOrder value, string column)
        {
            IEnumerable<AdminManagmentViewModel> modelsList = _adminService.OrderSort(value, column);

            return modelsList;
        }

        [HttpGet("GetSortedUsersByLastName")]
        public async Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByLastName(SortOrder value)
        {
            IEnumerable<ApplicationUserViewModel> users = await _applicationUserService.GetSortedUsersByLastName(value);

            return users;
        }

        [HttpGet("GetSortedUsersByFirstName")]
        public async Task<IEnumerable<ApplicationUserViewModel>> GetSortedUsersByFirstName(SortOrder value)
        {
            IEnumerable<ApplicationUserViewModel> users = await _applicationUserService.GetSortedUsersByFirstName(value);

            return users;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IEnumerable<AuthorViewModel>> GetAllAuthors()
        {
            IEnumerable<AuthorViewModel> authors = await _authorService.GetAll();

            return authors;
        }

        [HttpGet("FilterByOrderStatus")]
        public IEnumerable<AdminManagmentViewModel> FilterByOrderStatus(bool value)
        {
            IEnumerable<AdminManagmentViewModel> modelsList = _adminService.FilterByOrderStatus(value);

            return modelsList;
        }

        [HttpGet("OrderNumberSort")]
        public IEnumerable<AdminManagmentViewModel> OrderNumberSort(SortOrder value)
        {
            IEnumerable<AdminManagmentViewModel> modelsList = _adminService.OrderSort(value, "");

            return modelsList;
        }


        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody]AuthorViewModel model)
        {
            await _authorService.CreateAuthor(model);

            return Ok(201);
        }

        [HttpPost("AddPrintingEdition")]
        public async Task<IActionResult> AddPrintingEdition([FromBody]AuthorsInPrintingEditionsViewModel model)
        {
            await _printingEditionService.CreatePrintingEdition(model);

            return Ok(201);
        }

        [HttpPost("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor([FromBody]int id)
        {
            await _authorService.DeleteAuthor(id);

            return Ok(201);
        }

        [HttpPost("DeleteEdition")]
        public async Task<IActionResult> DeleteEdition([FromBody]int id)
        {
            await _printingEditionService.DeletePrintingEdition(id);

            return Ok(201);
        }

        [HttpPost("EditAuthor")]
        public async Task<IActionResult> EditAuthor([FromBody]AuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authorService.UpdateInformationAboutAuthor(model);

            return Ok(201);
        }

        [HttpPost("EditPrintingEdition")]
        public async Task<IActionResult> EditPrintingEdition([FromBody]AuthorsInPrintingEditionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _printingEditionService.UpdateInformationAboutPrintinEdition(model);

            return Ok(201);
        }
    }
}