using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class FishingEventController(IFishingEventService service) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<FishingEventALLModel> model = await service.GetAllEventsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            FishingEventAddModel model = new FishingEventAddModel();
            model.Locations = await service.GetLocationListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FishingEventAddModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await service.GetLocationListAsync();
                return View(model);
            }
            string? userId = GetUserId();
            await service.AddFishingEventAsync(model, userId);

            return RedirectToAction(nameof(All));
        }





    }
}
