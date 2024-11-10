using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class FishingEventController(IFishingEventService service) : BaseController
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(string? eventName)
        {
            string? userId = GetUserId();
            IEnumerable<FishingEventALLModel> model = await service.GetAllEventsAsync(userId, eventName);
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

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            FishingEvent fishEvent = await service.FindEventAsync(id);
            if (fishEvent == null || User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            string? userId = GetUserId();
            await service.JoinEventAsync(id, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var model = await service.FindEventAsync(id);
            if (model == null || User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            var userId = GetUserId();
            await service.LeaveAsync(model, userId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            FishingEventEditModel model = await service.GetEventToEditAsync(id);
            string? userId = GetUserId();
            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            if (model.OrganizerId != userId && !User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(FishingEventEditModel model, int id)
        {

            FishingEvent fishEvent = await service.FindEventAsync(id);
            string? userId = GetUserId();

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            if (model.OrganizerId != userId && !User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            await service.EditEventAsync(model, fishEvent);
            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.FindEventAsync(id);
            string userId = GetUserId();

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            if (model.OrganizerId != userId && !User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            FishingEventDeleteModel modelToDelete = new FishingEventDeleteModel()
            {
                Id = model.Id,
                Name = model.EventName,
            };
            return View(modelToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, FishingEventDeleteModel modelToDelete)
        {
            var entity = await service.FindEventAsync(id);
            if (entity == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            await service.DeleteEventAsync(entity);
            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = GetUserId();
            FishingEventDetailModel model = await service.GetEventDetailsAsync(id, userId);
            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AllEventParticipants(int id)
        {
            IEnumerable<FishingEventAllParticipants> model = await service.GetAllParticipant(id);
            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            return View(model);
        }
    }
}
