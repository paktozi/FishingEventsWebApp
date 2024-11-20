using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Errors/PageNotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [Route("Errors/ServerError")]
        public IActionResult ServerError()
        {
            return View();
        }

        [Route("Errors/Unauthorized")]
        public IActionResult Unauthorized()
        {
            return View();
        }

        [Route("Errors/DontBeClever")]
        public IActionResult DontBeClever()
        {
            return View();
        }
    }
}
