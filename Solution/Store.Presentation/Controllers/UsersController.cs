using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<UserModel> Index() => _userService.GetAll();


        [HttpPost("Create")]
        //[Authorize(Roles = "admin")]
        public async Task<HttpStatusCode> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.CreateAsync(model);

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
            var userEditModel = await _userService.FindByIdAsync(id);

            if (_userService.FindByIdAsync(id) == null)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;
        }

        [HttpPost("Edit")]
        public HttpStatusCode Edit(UserEditModel model)
        {
            if (ModelState.IsValid && _userService.IsUserExist(model))
            {
                try
                {
                    _userService.Update(model);
                    return HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.ToString());
                }
            }
            return HttpStatusCode.NotFound;
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<HttpStatusCode> Delete(string email)
        {
            await _userService.DeleteAsync(email);
            return HttpStatusCode.OK;
        }

        [HttpGet("ChangePassword")]
        public async Task<HttpStatusCode> ChangePasswordAsync(string id)
        {
            var userEditModel = await _userService.FindByIdAsync(id);

            if (userEditModel != null)
            {
                return HttpStatusCode.NotFound;
            }
            var model = new UserChangePasswordModel { Id = userEditModel.Id, Email = userEditModel.Email };
            return HttpStatusCode.OK;
        }

        [HttpPost("ChangePassword")]
        public async Task<HttpStatusCode> ChangePasswordAsync(UserChangePasswordModel model)
        {

            if (ModelState.IsValid)
            {
                UserModel editUserViewModel = await _userService.FindByEmailAsync(model.Email);
                if (editUserViewModel != null)
                {
                    try
                    {
                        await _userService.ChangePassword(model);
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

        [HttpGet("GetUser")]
        public async Task<UserModel> GetUserProfileAsync(string id)
        {
            UserModel editUserModel = await _userService.FindByIdAsync(id);
            return editUserModel;
        }
    }
}
