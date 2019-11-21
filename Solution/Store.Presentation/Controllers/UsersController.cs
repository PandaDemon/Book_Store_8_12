using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using Store.Presentation.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.Presentation.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IApplicationUserService _applicationUserService;

        public UsersController(IApplicationUserService applicationUserService, IOrderService orderService)
        {
            _applicationUserService = applicationUserService;
            _orderService = orderService;
        }

        [HttpGet("GetUserProfile")]
        [Authorize]
        public async Task<ApplicationUserViewModel> GetUserProfile()
        {
            string userId = User.Claims.First(claim => claim.Type == "UserID").Value;
            ApplicationUserViewModel user = await _applicationUserService.FindUserByIdAsync(userId);

            return user;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _applicationUserService.CreateUserAsync(model);

            if (!result.Succeeded)
            {
                return BadRequest("Failed");
            }

            return Ok(201);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody]EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult res = await _applicationUserService.EditApplicationUser(model);

            if (!res.Succeeded)
            {
                return BadRequest(420);
            }

            return Ok(201);
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromBody] string id)
        {
            IdentityResult result = await _applicationUserService.DeleteUserAsync(id);

            if (!result.Succeeded)
            {
                return BadRequest(404);
            }

            return Ok(200);
        }

        [HttpPost("ChangePassword")]
        public async Task<IdentityResult> ChangePassword([FromBody]ChangePasswordViewModel model)
        {
            IdentityResult res = await _applicationUserService.ChangeUserPassword(model);

            return res;
        }

        [HttpGet("GetUserProfileAsync")]
        public async Task<ApplicationUserViewModel> GetUserProfileAsync(string id)
        {
            ApplicationUserViewModel editUserViewModel = await _applicationUserService.FindUserByIdAsync(id);

            return editUserViewModel;
        }

        [HttpGet("GetUserOrders")]
        public IEnumerable<UserOrdersViewModel> GetUserOrders(string id)
        {
            IEnumerable<UserOrdersViewModel> modelsList = _orderService.GetOrdersByUserId(id);

            return modelsList;
        }
    }
}