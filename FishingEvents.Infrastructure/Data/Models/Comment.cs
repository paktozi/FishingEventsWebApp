using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        [Comment("Primary key identifier for the Comment")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentTextMaxLength)]
        [Comment("The text content of the comment.")]
        public string CommentText { get; set; } = null!;

        [Required]
        [Comment("The date and time when the comment was created.")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("The unique identifier for the author of the comment.")]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;

        [Comment("Navigation property representing the author of the comment.")]
        public ApplicationUser Author { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(FishingEvent))]
        [Comment("The unique identifier of the fishing event to which this comment is associated.")]
        public int FishingEventId { get; set; }

        [Comment("Navigation property representing the fishing event associated with the comment.")]
        public FishingEvent FishingEvent { get; set; } = null!;
    }
}
