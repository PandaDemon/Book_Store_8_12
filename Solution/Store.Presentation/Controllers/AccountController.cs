using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.JwtProvider;
using Store.BusinessLogic.JwtProvider.Interfaces;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
	public class AccountController : BaseApiController
    {
		public static string Succsessful = "Succsessful";
		public static string LogOutMessage = "You are logged out";
		public static string ForgotPasswordEmailSubject = "Get a new password";
	
		private readonly IAccountService _accountService;
		private readonly IJwtTokenValidator _jwtProvider;
		private readonly IEmailSender _emailSender;
		private readonly IUserService _userService;

        public AccountController(IUserService userService, IAccountService accountService, IEmailSender emailSender, IJwtTokenValidator jwtProvider)
        {
			_userService = userService;
			_accountService = accountService;
			_jwtProvider = jwtProvider;
			_emailSender = emailSender;
		}


		[HttpPost("SignUp")]
		public async Task<IActionResult> RegisterAsync(UserModel model)
		{
			var confirmationToken = await _accountService.RegisterAsync(model);
			if (!string.IsNullOrWhiteSpace(confirmationToken))
			{
				var callbackUrl = Url.Action("confirmRegistration", "Account",
					new { userEmail = model.Email, confirmToken = confirmationToken },
					protocol: HttpContext.Request.Scheme);
				await _emailSender.SendEmailAsync(model.Email, "Confirm Email",
					$"Confirm your account : {callbackUrl}");
				return Ok("We have sent an email with a confirmation link to your email address. In order to complete the sign-up process, please click click the confirmation link.");
			}
			return BadRequest("Failed");
		}

		[HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            var tokenResponseModel = await _userService.SignInAsync(model);

            if (tokenResponseModel != null)
            {
                return Ok(tokenResponseModel);
            }

            return BadRequest("Login failed");
        }

        [HttpPost("LogOut")]
        public async Task LogOut()
        {
            await _userService.LogOutAsync();
        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }
            var user = await _userService.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("There is no such user");
            }
            var result = await _userService.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Accepted("Password was updated");
            }
            return Ok();
        }

        [HttpPost("ConfirmEmail")]
        public async Task<UserModel> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return null;
            }

            var user = await _userService.FindByIdAsync(userId);
            var result = _userService.ConfirmEmail(user, code);

            if (result.Result.Succeeded)
            {
                return user;
            }

            return null;
        }
    }
}
