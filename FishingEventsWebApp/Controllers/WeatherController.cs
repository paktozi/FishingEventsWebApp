using FishingEvents.Infrastructure.Data.Models.WeatherModels;
using FishingEventsApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class WeatherController(WeatherService service) : Controller
    {
        public async Task<IActionResult> SearchLocation()
        {
            return View();
        }

        public async Task<ActionResult> Index(string locationName)
        {
            try
            {
                Weather weatherData = await service.GetWeatherAsync(locationName);
                return View(weatherData);
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = "Unable to fetch weather data.";
                return RedirectToAction(nameof(ErrorsController.ServerError), "Errors");
            }
        }
    }
}
