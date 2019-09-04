/*using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Role;
using Store.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        UserManager<User> userManager;
        RoleManager<Role> roleManager;

        public RolesController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index() => View(roleManager.Roles.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Role role = new Role { Name = name };
                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return PartialView();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.ToString());
                    }
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Role role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
            }
            return PartialView();
        }
        public IActionResult UserList() => View(userManager.Users.ToList());

        public async Task<IActionResult> EditUserRole(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var allRoles = roleManager.Roles.ToList();

                ChangeRoleViewModel model = new ChangeRoleViewModel { UserEmail = user.Email, AllRoles = allRoles, UserRoles = userRoles, UserId = userId };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            User user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var allroles = roleManager.Roles.ToList();

                var addedRoles = roles.Except(userRoles);

                var removedRoles = userRoles.Except(roles);

                await userManager.AddToRolesAsync(user, addedRoles);

                await userManager.RemoveFromRolesAsync(user, removedRoles);

                return PartialView();
            }
            return NotFound();
        }
    }
}
*/