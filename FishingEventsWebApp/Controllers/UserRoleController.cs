using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.UserRoleModel;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [GlobalAdminAuthorize]
    public class UserRoleController(IUserRoleService userRoleService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AssignRole()
        {
            var usersNotInAdmin = await userRoleService.GetUsersNotInRoleAsync("Admin");
            var roles = await userRoleService.GetRolesAsync();

            var model = new AssignRoleViewModel
            {
                Users = usersNotInAdmin,
                Roles = roles.Select(role => new SelectListItemModel
                {
                    Text = role,
                    Value = role
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userRoleService.GetUserByIdAsync(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View(model);
                }

                var result = await userRoleService.AddUserToRoleAsync(user, model.SelectedRole);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = $"User {user.UserName} has been successfully assigned to the {model.SelectedRole} role.";
                    return RedirectToAction(nameof(AssignRole));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole()
        {
            var usersInAdmin = await userRoleService.GetUsersInRoleAsync("Admin");
            var roles = await userRoleService.GetRolesAsync();

            var model = new AssignRoleViewModel
            {
                Users = usersInAdmin,
                Roles = roles.Select(role => new SelectListItemModel
                {
                    Text = role,
                    Value = role
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole(AssignRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userRoleService.GetUserByIdAsync(model.UserId);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found.");
                    return View("RemoveRole", model);
                }

                var result = await userRoleService.RemoveUserFromRoleAsync(user, model.SelectedRole);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = $"Role {model.SelectedRole} has been removed from {user.UserName}.";
                    return RedirectToAction(nameof(RemoveRole));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("RemoveRole", model);
        }
    }
}
