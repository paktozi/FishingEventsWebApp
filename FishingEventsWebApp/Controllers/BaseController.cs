using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            string? userId = string.Empty;

            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId;
        }

        protected bool IsAdminOrGlobalAdmin()
        {
            return User.IsInRole(AdminRole) || User.IsInRole(GlobalAdminRole);
        }


        protected IActionResult PageNotFoundError()
        {
            return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");

        }
        protected IActionResult UnauthorizedError()
        {
            return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
        }

        protected IActionResult ServerError()
        {
            return RedirectToAction(nameof(ErrorsController.ServerError), "Errors");
        }
    }
}
