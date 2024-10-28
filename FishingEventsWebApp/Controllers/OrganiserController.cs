using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class OrganiserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BecomeOrganiser()
        {
            return RedirectToAction(nameof(FishingEventController.All), "FishingEvent");
        }
    }
}
