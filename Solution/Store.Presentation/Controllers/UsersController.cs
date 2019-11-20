using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Linq;
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

        [HttpGet("GetUser")]
        public async Task<object> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return users;
        }

        [HttpPost("Create")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }
            var result = await _userService.Create(model);
            if (result.Succeeded)
            {
                return Ok("Created");
            }
            else
            {
                return BadRequest("Failed");
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request");
            }
            IdentityResult res = await _userService.Update(model);
            if (res.Succeeded)
            {
                return Ok("Saved");
            }
            return BadRequest("Failed");
        }

        
        [HttpPost("Delete")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(UserModel id)
        {
            var buffer = new byte[0];
            var test = Request.Body.Read(buffer, 0, (int)Request.Body.Length);
            IdentityResult result = await _userService.Delete(id.Id);
            if (result.Succeeded)
            {
                return Ok(200);
            }
            return BadRequest("User not found");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordModel model)
        {
            IdentityResult res = await _userService.ChangePassword(model);

            if (res.Succeeded)
            {
                return Ok("Password was changed");
            }
            else
            {
                return BadRequest(res.Errors);
            }
        }

        
        [HttpGet("GetUser")]
        public async Task<Object> GetUserProfileAsync()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userService.FindByIdAsync(userId);
            //UserModel editUserModel = await _userService.FindByIdAsync(id);
            //return editUserModel;
            return new
            {
                user.FirstName,
                user.Email
            };
        }
    }
}
