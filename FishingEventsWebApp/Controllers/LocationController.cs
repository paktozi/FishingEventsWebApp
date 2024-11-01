using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult All()
        {
            return View();
        }


    }
}
