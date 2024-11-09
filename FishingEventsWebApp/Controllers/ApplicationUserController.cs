using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class ApplicationUserController(IApplicationUserService userService) : Controller
    {
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> All()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            ICollection<ApplicationUserAllModel> model = await userService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            ApplicationUserDetailsModel model = await userService.GetDetailsAsync(id);
            return View(model);
        }
    }
}
