using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface ICommentService
    {
        Task AddCommentAsync(string? currentUserId, int id, CommentAddModel model);
        Task EditCommentAsync(CommentEditModel model, Comment comment);
        Task<Comment> FindCommentAsync(int commentId);
        Task<CommentEditModel> GetCommentToEdit(int commentId);
        Task<ICollection<CommentAllModel>> GetAllCommentsAsync(int id, string? currentUserId);
        Task DeleteCommentAsync(Comment entity);
    }
}
