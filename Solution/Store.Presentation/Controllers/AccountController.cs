using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrintStore.BusinessLogic.Services;
using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.BusinessLogic.ViewModels;
using Store.Presentation.Controllers;
using System.Threading.Tasks;

namespace PrintStore.Presentation.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IApplicationUserService _applicationUserService;
        private const string CONFIRM = "ConfirmEmail";
        private const string ACCOUNT = "Account";
        private const string MESSAGECONFIRM = "Confirm email";
        private const string MESSAGERESET = "Reset Password";
        private const string COMPLITE = "To complete the action, follow the link ::";

        public AccountController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        [HttpGet("ConfirmEmail")]
        public async Task<ApplicationUserViewModel> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return null;
            }

            ApplicationUserViewModel user = await _applicationUserService.FindUserByIdAsync(userId);
            IdentityResult result = await _applicationUserService.ConfirmEmail(user, code);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        [HttpPost("ConfirmEmailAsync")]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody]RegisterUserViewModel model)
        {
            ApplicationUserViewModel applicationUserView = await _applicationUserService.FindByEmailAsync(model.Email);
            string code1 = await _applicationUserService.GenerateEmailConfirmationTokenAsync(model);

            string callbackUrl = Url.Action(CONFIRM, ACCOUNT, new { userId = applicationUserView.Id, code = code1 }, protocol: Request.Scheme);
            string linkString = $"<a href = \"{callbackUrl} \"> complete registration </a>";
            var messageBody = $"{COMPLITE} {linkString}";

            new EmailService().SendEmail(model.Email, MESSAGECONFIRM, messageBody);

            return Ok(200);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _applicationUserService.RegisterUser(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(200);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            TokenResponseModel tokenResponseModel = await _applicationUserService.SignInAsync(model);

            if (tokenResponseModel != null)
            {
                return Ok(tokenResponseModel);
            }

            return BadRequest(203);
        }

        [HttpPost("LogOff")]
        public async Task LogOff()
        {
            await _applicationUserService.SignOutAsync();
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ApplicationUserViewModel user = await _applicationUserService.FindByEmailAsync(model.Email);

            if (user == null || !await _applicationUserService.IsEmailConfirmedAsync(user))
            {
                return NotFound(404);
            }

            string code1 = await _applicationUserService.GeneratePasswordResetTokenAsync(user);
            string callbackUrl = Url.RouteUrl("ResetPassword", new { userId = user.Id, code = code1 });
            string linkString = $"<a href = \"{callbackUrl} \"> reset </a>";
            string messageBody = $"{COMPLITE} {linkString}";

            new EmailService().SendEmail(model.Email, MESSAGERESET, messageBody);

            return Ok(200);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUserViewModel user = await _applicationUserService.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound(404);
            }

            IdentityResult result = await _applicationUserService.ResetPasswordAsync(user, model.Code, model.Password);

            if (!result.Succeeded)
            {
                return Accepted(420);
            }

            return Accepted(200);
        }
    }
}