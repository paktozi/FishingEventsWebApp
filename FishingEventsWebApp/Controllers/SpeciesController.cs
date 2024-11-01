using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class SpeciesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
