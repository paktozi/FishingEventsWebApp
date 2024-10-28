using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
using FishingEventsApp.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        //public async Task<IActionResult> Join(int id)
        //{
        //    FishingEvent fishEvent = await service.GetEventByIdAsync(id);
        //    if (fishEvent == null)
        //    {
        //        return BadRequest();
        //    }
        //    string? userId = GetUserId();
        //    await service.JoinEventAsync(id, userId);
        //    return RedirectToAction(nameof(All));
        //}

    }
}
