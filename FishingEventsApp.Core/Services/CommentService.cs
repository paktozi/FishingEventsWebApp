using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.CommentModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static FishingEventsApp.Common.ValidationConstants;


namespace FishingEventsApp.Core.Services
{
    public class CommentService(FishingEventsDbContext context) : ICommentService
    {
        public async Task AddCommentAsync(string? currentUserId, int id, CommentAddModel model)
        {
            Comment entity = new Comment();

            entity.CommentText = model.CommentText;
            entity.AuthorId = currentUserId;
            entity.CreatedOn = DateTime.Now;
            entity.FishingEventId = id;

            await context.Comments.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditCommentAsync(CommentEditModel model, Comment comment)
        {
            comment.CommentText = model.CommentText;
            comment.CreatedOn = DateTime.Now;
            await context.SaveChangesAsync();
        }

        public async Task<Comment> FindCommentAsync(int commentId)
        {
            return await context.Comments.FindAsync(commentId);
        }

        public async Task<CommentEditModel> GetCommentToEdit(int commentId)
        {
            var comment = await context.Comments
                .Where(c => c.Id == commentId)
                .Select(c => new CommentEditModel()
                {
                    Id = c.Id,
                    CommentText = c.CommentText
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return comment;
        }

        public async Task<ICollection<CommentAllModel>> GetAllCommentsAsync(int id, string? currentUserId)
        {
            var model = await context.Comments
                .Where(c => c.FishingEventId == id)
                .Select(c => new CommentAllModel()
                {
                    Id = c.Id,
                    CommentText = c.CommentText,
                    CreatedOn = c.CreatedOn.ToString(DateFormat),
                    AuthorId = c.AuthorId,
                    FishingEventId = c.FishingEventId,
                    IsAuthor = c.AuthorId == currentUserId,
                    AuthorName = $"{c.Author.FirstName} {c.Author.LastName}"
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }

        public async Task DeleteCommentAsync(Comment entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
