using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class FishCaughtController(IFishCaughtService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All(string userId, int id)
        {
            ICollection<FishCaughtAllModel> model = await service.GetMyCaughtsAsync(userId, id);
            return View(model);
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Add(string userId, int id)
        {
            FishCaughtAddModel model = new FishCaughtAddModel();
            model.ListSpecies = await service.GetListSpeciesAsync();
            model.UserId = userId;
            model.FishingEventId = id;
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Edit(string userId, int eventId, int id)
        {
            FishCaughtEditModel model = await service.GetCaughtToEditAsync(id);
            model.ListSpecies = await service.GetListSpeciesAsync();
            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FishCaughtEditModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FishCaught fishCaught = await service.FindCaughtAsync(id);

            if (fishCaught == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            await service.EditCaughtAsync(model, fishCaught);
            return RedirectToAction("AllEventParticipants", "FishingEvent", new { id = fishCaught.FishingEventId });
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Delete(int id, int eventId)
        {
            FishCaught model = await service.FindCaughtToDeleteAsync(id);

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }

            FishCaughtDeleteModel modelToDelete = new FishCaughtDeleteModel()
            {
                Id = model.Id,
                EventName = model.FishingEvent.EventName,
                FishName = model.Species.Name,
                Weight = model.Weight,
                Length = model.Length,
            };
            return View(modelToDelete);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(FishCaughtDeleteModel modelToDelete, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(modelToDelete);
            }
            var entity = await service.FindCaughtAsync(id);
            var fishingEventId = entity.FishingEventId;
            if (entity == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            await service.DeleteCaughtAsync(entity);
            return RedirectToAction("AllEventParticipants", "FishingEvent", new { id = fishingEventId });
        }
    }
}
