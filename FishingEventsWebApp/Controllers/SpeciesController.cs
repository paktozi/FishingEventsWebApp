using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsWebApp.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class SpeciesController(ISpeciesService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<SpeciesAllModel> model = await service.GetAllSpeciesAsync();
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
        public async Task<IActionResult> Edit(SpeciesEditModel model, int id)
        {
            Species speciesToEdit = await service.FindSpeciesAsync(id);
            if (speciesToEdit == null)
            {
                return RedirectToAction(nameof(All));
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
                return NotFound();
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
        public async Task<IActionResult> DeleteConfirmed(SpeciesDeleteModel model, int id)
        {
            var modelToDelete = await service.FindSpeciesAsync(id);
            if (modelToDelete == null)
            {
                return NotFound();
            }
            await service.DeleteFishAsync(modelToDelete);
            return RedirectToAction(nameof(All));
        }
    }
}
