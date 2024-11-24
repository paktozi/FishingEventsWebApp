using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.CommentModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsWebApp.Controllers
{
    [Authorize]
    public class CommentController(ICommentService service) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            string? currentUserId = GetUserId();
            ICollection<CommentAllModel> model = await service.GetAllCommentsAsync(id, currentUserId);
            TempData["eventId"] = id;
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            CommentAddModel model = new CommentAddModel();
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(CommentAddModel model, int id)
        {
            string? currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await service.AddCommentAsync(currentUserId, id, model);
            return RedirectToAction(nameof(All), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int commentId, int eventId, string authorId)
        {
            string? currentUserId = GetUserId();

            if (authorId != currentUserId && !User.IsInRole(AdminRole) && !User.IsInRole(GlobalAdminRole))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            CommentEditModel model = await service.GetCommentToEdit(commentId);

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(CommentEditModel model, int Id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Comment comment = await service.FindCommentAsync(Id);
            if (comment == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            await service.EditCommentAsync(model, comment);
            return RedirectToAction(nameof(All), new { id = comment.FishingEventId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int commentId, int eventId)
        {
            string? userId = GetUserId();

            var model = await service.FindCommentAsync(commentId);

            if (model == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }
            if (model.AuthorId != userId && !User.IsInRole(AdminRole) && !User.IsInRole(GlobalAdminRole))
            {
                return RedirectToAction(nameof(ErrorsController.Unauthorized), "Errors");
            }

            CommentDeleteModel modelToDelete = new CommentDeleteModel()
            {
                Id = model.Id,
                CommentText = model.CommentText,
            };
            return View(modelToDelete);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(CommentDeleteModel modelToDelete, int Id)
        {
            if (!ModelState.IsValid)
            {
                return View(modelToDelete);
            }

            var entity = await service.FindCommentAsync(Id);
            int fishingEventId = entity.FishingEventId;

            if (entity == null)
            {
                return RedirectToAction(nameof(ErrorsController.PageNotFound), "Errors");
            }

            await service.DeleteCommentAsync(entity);
            return RedirectToAction(nameof(All), new { id = fishingEventId });
        }
    }
}
