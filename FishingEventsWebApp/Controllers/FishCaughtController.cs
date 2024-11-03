using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class FishCaughtController : Controller
    {
        public IActionResult All(int id)
        {
            return View();
        }
    }
}
