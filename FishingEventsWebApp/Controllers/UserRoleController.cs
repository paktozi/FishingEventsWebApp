using FishingEventsApp.Core.Contracts;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [GlobalAdminAuthorize]
    public class UserRoleController(IUserRoleService userRoleService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var usersWithRoles = await userRoleService.GetUsersWithRolesAsync();
            return View(usersWithRoles);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddAdminRole(string userId)
        {
            var result = await userRoleService.AddRoleToUserAsync(userId, "Admin");
            if (result)
            {
                TempData["Success"] = "Role added successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to add role.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RemoveAdminRole(string userId)
        {
            var result = await userRoleService.RemoveRoleFromUserAsync(userId, "Admin");
            if (result)
            {
                TempData["Success"] = "Role removed successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to remove role.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
