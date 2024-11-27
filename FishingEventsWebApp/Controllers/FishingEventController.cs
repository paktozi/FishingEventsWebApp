using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FishingEventsApp.Common.ValidationConstants;


namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class FishingEventController(IFishingEventService service) : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(string? searchValue, string? radioOption)
        {
            string? userId = GetUserId();
            IEnumerable<FishingEventALLModel> model = await service.GetAllEventsAsync(userId, searchValue, radioOption);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(FishingEventAddModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await service.GetLocationListAsync();
                return View(model);
            }
            string? userId = GetUserId();
            await service.AddFishingEventAsync(model, userId);

            return RedirectToAction(nameof(All), new { model.EventName });
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            FishingEvent fishEvent = await service.FindEventAsync(id);
            if (fishEvent == null || IsAdminOrGlobalAdmin())
            {
                return PageNotFoundError();
            }
            string? userId = GetUserId();
            await service.JoinEventAsync(id, userId);

            return RedirectToAction(nameof(All), new { fishEvent.EventName });
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            FishingEvent model = await service.FindEventAsync(id);

            if (model == null || IsAdminOrGlobalAdmin())
            {
                return PageNotFoundError();
            }

            var userId = GetUserId();
            await service.LeaveAsync(model, userId);

            return RedirectToAction(nameof(All), new { model.EventName });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            FishingEventEditModel model = await service.GetEventToEditAsync(id);
            string? userId = GetUserId();

            if (model == null)
            {
                return PageNotFoundError();
            }
            if (model.OrganizerId != userId && !IsAdminOrGlobalAdmin())
            {
                return UnauthorizedError();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FishingEventEditModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            FishingEvent fishEvent = await service.FindEventAsync(id);

            if (fishEvent == null)
            {
                return PageNotFoundError();
            }

            string? userId = GetUserId();

            if (fishEvent.OrganizerId != userId && !IsAdminOrGlobalAdmin())
            {
                return UnauthorizedError();
            }

            await service.EditEventAsync(model, fishEvent);
            return RedirectToAction(nameof(All), new { fishEvent.EventName });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.FindEventAsync(id);
            string? userId = GetUserId();

            if (model == null)
            {
                return PageNotFoundError();
            }
            if (model.OrganizerId != userId && !IsAdminOrGlobalAdmin())
            {
                return UnauthorizedError();
            }

            FishingEventDeleteModel modelToDelete = new FishingEventDeleteModel()
            {
                Id = model.Id,
                Name = model.EventName,
            };
            return View(modelToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, FishingEventDeleteModel modelToDelete)
        {
            if (!ModelState.IsValid)
            {
                return View(modelToDelete);
            }

            var entity = await service.FindEventAsync(id);

            if (entity == null)
            {
                return PageNotFoundError();
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
                return PageNotFoundError();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllEventParticipants(int id)
        {
            ViewData["CurrentUserId"] = GetUserId();

            IEnumerable<FishingEventAllParticipants> model = await service.GetAllParticipant(id);
            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            return View(model);
        }
    }
}
