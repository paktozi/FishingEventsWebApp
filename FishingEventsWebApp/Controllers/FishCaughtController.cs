using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.FishCaughtModels;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    public class FishCaughtController(IFishCaughtService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All(string userId, int id)
        {
            ICollection<FishCaughtAllModel> model = await service.GetMyCaughtsAsync(userId, id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(string userId, int id)
        {
            FishCaughtAddModel model = new FishCaughtAddModel();
            model.ListSpecies = await service.GetListSpeciesAsync();
            model.UserId = userId;
            model.FishingEventId = id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FishCaughtAddModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ListSpecies = await service.GetListSpeciesAsync();
                return View(model);
            }
            await service.AddFishAsync(model);
            return RedirectToAction("AllEventParticipants", "FishingEvent", new { id = model.FishingEventId });
        }
    }
}
