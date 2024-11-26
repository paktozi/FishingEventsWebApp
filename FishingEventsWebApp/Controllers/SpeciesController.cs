using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class SpeciesController(ISpeciesService service) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All(string? specieName)
        {
            IEnumerable<SpeciesAllModel> model = await service.GetAllSpeciesAsync(specieName);
            return View(model);
        }

        [HttpGet]
        [AdminAuthorize]
        public IActionResult Add()
        {
            SpeciesAddModel model = new SpeciesAddModel();
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(SpeciesAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await service.AddFishAsync(model);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Edit(int id)
        {
            SpeciesEditModel model = await service.GetSpeciesToEdit(id);
            if (model == null)
            {
                return RedirectToAction(nameof(All));
            }
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpeciesEditModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Species speciesToEdit = await service.FindSpeciesAsync(id);

            if (speciesToEdit == null)
            {
                return PageNotFoundError();
            }

            await service.EditSpeciesAsync(model, speciesToEdit);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [AdminAuthorize]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await service.FindSpeciesAsync(id);
            if (model == null)
            {
                return PageNotFoundError();
            }
            SpeciesDeleteModel modelToDelete = new SpeciesDeleteModel()
            {
                Id = id,
                Name = model.Name
            };
            return View(modelToDelete);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(SpeciesDeleteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var modelToDelete = await service.FindSpeciesAsync(id);

            if (modelToDelete == null)
            {
                return PageNotFoundError();
            }
            await service.DeleteFishAsync(modelToDelete);
            return RedirectToAction(nameof(All));
        }
    }
}
