using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
using FishingEventsApp.Core.Models.LocationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class LocationController(ILocationService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<FishingLocationModel> model = await service.GetAllLocationsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            LocationAddModel model = new LocationAddModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LocationAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.AddLocationAsync(model);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            LocationEditModel model = await service.GetLocationToEdit(id);
            if (model == null)
            {
                return RedirectToAction(nameof(All));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LocationEditModel model, int id)
        {
            Location locationToEdit = await service.FindLocationAsync(id);
            if (locationToEdit == null)
            {
                return RedirectToAction(nameof(All));
            }

            await service.EditLocationAsync(model, locationToEdit);

            return RedirectToAction(nameof(All));
        }


    }
}
