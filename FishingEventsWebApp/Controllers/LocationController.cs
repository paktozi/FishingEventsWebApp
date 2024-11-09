using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.LocationModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class LocationController(ILocationService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<FishingLocationModel> model = await service.GetAllLocationsAsync();
            return View(model);
        }

        [HttpGet]
        [AdminAuthorize]
        public IActionResult Add()
        {
            LocationAddModel model = new LocationAddModel();
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
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
        [AdminAuthorize]
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
        [AdminAuthorize]
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

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.FindLocationAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            LocationDeleteModel modelToDelete = new LocationDeleteModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
            return View(modelToDelete);
        }


        [HttpPost]
        [AdminAuthorize]
        public async Task<IActionResult> DeleteConfirmed(int id, LocationDeleteModel modelToDelete)
        {
            var entity = await service.FindLocationAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            await service.DeleteLocationAsync(entity);
            return RedirectToAction(nameof(All));
        }
    }
}
