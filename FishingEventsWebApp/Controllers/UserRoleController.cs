using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsWebApp.Controllers
{
    [GlobalAdminAuthorize]

    public class UserRoleController(IUserRoleService userRoleService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usersWithRoles = await userRoleService.GetUsersWithRolesAsync();
            return View(usersWithRoles);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddAdminRole(string userId)
        {
            var result = await userRoleService.AddRoleToUserAsync(userId, AdminRole);
            if (result)
            {
                TempData["Success"] = RoleAddedSuccessMessage;
            }
            else
            {
                TempData["Error"] = RoleAddedFailMessage;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> RemoveAdminRole(string userId)
        {
            var result = await userRoleService.RemoveRoleFromUserAsync(userId, AdminRole);
            if (result)
            {
                TempData["Success"] = RoleRemovedSuccessMessage;
            }
            else
            {
                TempData["Error"] = RoleRemovedFailMessage;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string userId)
        {
            ApplicationUser model = await userRoleService.FindUserAsync(userId);

            if (model == null)
            {
                return PageNotFoundError();
            }
            if (!User.IsInRole(GlobalAdminRole))
            {
                return UnauthorizedError();
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
                return PageNotFoundError();
            }
            string? globalAdminId = GetUserId();
            await userRoleService.DeleteUserAsync(entity, userId, globalAdminId);
            return RedirectToAction(nameof(Index));
        }
    }
}
