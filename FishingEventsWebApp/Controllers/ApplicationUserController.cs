using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class ApplicationUserController(IApplicationUserService userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All(string? userName)
        {
            ICollection<ApplicationUserAllModel> model = await userService.GetAllAsync(userName);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ApplicationUserDetailsModel model = await userService.GetDetailsAsync(id);
            return View(model);
        }
    }
}
