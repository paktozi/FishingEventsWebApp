﻿using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class FishCaughtController(IFishCaughtService service) : BaseController
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
            string? currentUserId = GetUserId();

            if (userId != currentUserId)      //  if the user is an admin, he cannot add fish to himself
            {
                FishCaughtAddModel model = new FishCaughtAddModel();
                model.ListSpecies = await service.GetListSpeciesAsync();
                model.UserId = userId;
                model.FishingEventId = id;
                return View(model);
            }
            return RedirectToAction(nameof(ErrorsController.DontBeClever), "Errors");
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
            return RedirectToAction(nameof(FishingEventController.AllEventParticipants), "FishingEvent", new { id = model.FishingEventId });
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Edit(string userId, int eventId, int id)
        {
            string? currentUserId = GetUserId();

            if (userId != currentUserId)      //  if the user is an admin, he cannot edit fish to himself
            {
                FishCaughtEditModel model = await service.GetCaughtToEditAsync(id);
                model.ListSpecies = await service.GetListSpeciesAsync();
                if (model == null)
                {
                    return PageNotFoundError();
                }
                return View(model);
            }

            return RedirectToAction(nameof(ErrorsController.DontBeClever), "Errors");
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
                return PageNotFoundError();
            }
            await service.EditCaughtAsync(model, fishCaught);
            return RedirectToAction(nameof(FishingEventController.AllEventParticipants), "FishingEvent", new { id = fishCaught.FishingEventId });
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Delete(int id, int eventId)
        {
            FishCaught model = await service.FindCaughtToDeleteAsync(id);   //if the user is an admin, he can delete fish to himself,which will lower his rating :) 

            if (model == null)
            {
                return PageNotFoundError();
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
                return PageNotFoundError();
            }
            await service.DeleteCaughtAsync(entity);
            return RedirectToAction(nameof(FishingEventController.AllEventParticipants), "FishingEvent", new { id = fishingEventId });
        }
    }
}
