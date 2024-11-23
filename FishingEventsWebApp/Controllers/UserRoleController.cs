using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace FishingEventsWebApp.Controllers
{
    [GlobalAdminAuthorize]
    public class UserRoleController(IUserRoleService userRoleService) : BaseController
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

        [HttpGet]
        public async Task<IActionResult> Delete(string userId)
        {
            ApplicationUser model = await userRoleService.FindUserAsync(userId);

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            if (!User.IsInRole("GlobalAdmin"))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            ApplicationUserDeleteModel userToDelete = new ApplicationUserDeleteModel()
            {
                UserId = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            return View(userToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ApplicationUserDeleteModel userToDelete, string userId)
        {
            if (!ModelState.IsValid)
            {
                return View(userToDelete);
            }

            var entity = await userRoleService.FindUserAsync(userId);

            if (entity == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            string? globalAdminId = GetUserId();
            await userRoleService.DeleteUserAsync(entity, userId, globalAdminId);
            return RedirectToAction(nameof(Index));
        }
    }
}
