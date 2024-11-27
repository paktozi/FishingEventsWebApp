using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Errors/PageNotFound")]
        public IActionResult PageNotFound() => View();

        [Route("Errors/ServerError")]
        public IActionResult ServerError() => View();

        [Route("Errors/Unauthorized")]
        public IActionResult Unauthorized() => View();

        [Route("Errors/DontBeClever")]
        public IActionResult DontBeClever() => View();
    }
}
