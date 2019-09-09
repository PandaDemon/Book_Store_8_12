using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService applicationUserService)
        {
            this._userService = applicationUserService;
        }

        public IEnumerable<UserModel> Index() => _userService.GetAll();


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<HttpStatusCode> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.UserCreateAsync(model);
                    if (result.Succeeded)
                    {
                        return HttpStatusCode.Created;
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.ToString());
                }
            }
            return HttpStatusCode.NoContent;
        }

        public async Task<HttpStatusCode> EditAsync(string id)
        {
            var userEditModel = await _userService.FindUserByIdAsync(id);

            if (_userService.FindUserByIdAsync(id) == null)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;
        }

        [HttpPost]
        public HttpStatusCode Edit(UserEditModel model)
        {

            if (ModelState.IsValid)
            {

                if (_userService.IsUserExist(model))
                {
                    try
                    {
                        _userService.UserEdit(model);
                        return HttpStatusCode.OK;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                    }

                }
            }
            return HttpStatusCode.NotFound;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<HttpStatusCode> Delete(string email)
        {
            await _userService.UserDeleteAsync(email);
            return HttpStatusCode.OK;
        }

        [HttpGet]
        public async Task<HttpStatusCode> ChangePasswordAsync(string id)
        {
            var userEditModel = await _userService.FindUserByIdAsync(id);

            if (userEditModel != null)
            {
                return HttpStatusCode.NotFound;
            }
            var model = new UserChangePasswordModel { Id = userEditModel.Id, Email = userEditModel.Email };
            return HttpStatusCode.OK;
        }

        [HttpPost]
        public async Task<HttpStatusCode> ChangePasswordAsync(UserChangePasswordModel model)
        {

            if (ModelState.IsValid)
            {
                UserModel editUserViewModel = await _userService.FindByEmailAsync(model.Email);
                if (editUserViewModel != null)
                {
                    try
                    {
                        await _userService.UserChangePassword(model);
                        return HttpStatusCode.OK;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There is no such user");
                }
            }
            return HttpStatusCode.NotFound;

        }

        [HttpGet]
        public async Task<UserModel> GetUserProfileAsync(string id)
        {
            UserModel editUserViewModel = await _userService.FindUserByIdAsync(id);
            return editUserViewModel;
        }
    }
}
