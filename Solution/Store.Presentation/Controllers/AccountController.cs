using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService applicationUserService)
        {
            this._userService = applicationUserService;
        }


        [HttpGet]
        public async Task<UserModel> ConfirmEmail(string userId, string code)
        {
            if (userId != null && code != null)
            {
                var user = await _userService.FindUserByIdAsync(userId);
                await _userService.ConfirmEmail(user, code);
                var result = _userService.ConfirmEmail(user, code);
                if (result.Result.Succeeded)
                {
                    return user;
                }
                else
                {
                    foreach (var error in result.Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return null;
        }

        [HttpPost]
        public async Task<Object> Register([FromBody]UserRegisterModel model)
        {
            IdentityResult res = new IdentityResult();
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUser(model);
                res = result;
                if (result.Succeeded)
                {

                    string code1 = await _userService.GenerateEmailConfirmationTokenAsync(model);
                    var applicationUserView = await _userService.FindByEmailAsync(model.Email);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = applicationUserView.Id, code = code1 },
                            protocol: Request.Scheme);
                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return res;

        }

        [HttpGet]
        public string Login(string returnUrl = null)
        {
            return "login";
        }

        [HttpPost]
        public async Task<HttpStatusCode> LogOff()
        {
            await _userService.SignOutAsync();
            return HttpStatusCode.Redirect;
        }

        [HttpGet]
        public string ForgotPassword()
        {
            return "Forgot tPassword";
        }

        [HttpPost]
        public async Task<HttpStatusCode> ForgotPassword(UserRecoveryPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userService.FindByEmailAsync(model.Email);
                if (user == null || !await _userService.IsEmailConfirmedAsync(user))
                {
                    return HttpStatusCode.Found;
                }

                string code1 = await _userService.GeneratePasswordResetTokenAsync(user);
            }
            return HttpStatusCode.NotFound;

        }

        [HttpGet]
        public HttpStatusCode ResetPassword(string code = null)
        {
            return code == null ? HttpStatusCode.Locked : HttpStatusCode.Redirect;
        }

        [HttpPost]
        public async Task<HttpStatusCode> ResetPassword(UserResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return HttpStatusCode.BadRequest;
            }
            var user = await _userService.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return HttpStatusCode.NotFound;
            }
            var result = await _userService.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return HttpStatusCode.Accepted;
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return HttpStatusCode.OK;
        }

    }
}
