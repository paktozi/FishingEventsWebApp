using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace FishingEventsWebApp.Controllers
{
    public class FishingEventController(IFishingEventService service) : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> All()
        {
            string? userId = GetCurrentUserId();
            IEnumerable<FishingEventALLModel> model = await service.GetAllEventsAsync(userId);
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


        public async Task<IActionResult> Join(int id)
        {
            FishingEvent fishEvent = await service.FindEventAsync(id);
            if (fishEvent == null)
            {
                return BadRequest();
            }
            string? userId = GetUserId();
            await service.JoinEventAsync(id, userId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var model = await service.FindEventAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            var userId = GetUserId();
            await service.LeaveAsync(model, userId);
            return RedirectToAction(nameof(All));
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.FindEventAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            string userId = GetUserId();
            if (model.OrganizerId != userId)
            {
                return Unauthorized();
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
                return NotFound();
            }
            await service.DeleteEventAsync(entity);
            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            FishingEventDetailModel model = await service.GetEventDetailsAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            FishingEventEditModel model = await service.GetEventToEditAsync(id);
            string? userId = GetUserId();

            if (model.OrganizerId != userId)
            {
                return Unauthorized();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FishingEventEditModel model, int id)
        {
            FishingEvent fishEvent = await service.FindEventAsync(id);
            if (fishEvent == null)
            {
                return BadRequest();
            }

            string? userId = GetUserId();

            if (fishEvent.OrganizerId != userId)
            {
                return Unauthorized();
            }

            await service.EditEventAsync(model, fishEvent);
            return RedirectToAction(nameof(All));
        }
    }
}
