using FishingEvents.Infrastructure.Data.Models.WeatherModels;
using FishingEventsApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class WeatherController(WeatherService service) : BaseController
    {
        public IActionResult SearchLocation() => View();

        public async Task<ActionResult> Index(string locationName)
        {
            try
            {
                Weather weatherData = await service.GetWeatherAsync(locationName);
                return View(weatherData);
            }
            catch (HttpRequestException)
            {
                return (ActionResult)ServerError();
            }
        }
    }
}
