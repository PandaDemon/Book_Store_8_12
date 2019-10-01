using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.SignUp(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return BadRequest("Model is not valid");
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
