using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class ApplicationUserController(IApplicationUserService userService) : Controller
    {
        [Authorize]

        public async Task<IActionResult> All()
        {
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
