using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.CommentModels
{
    public class CommentAddModel
    {
        [Required]
        [StringLength(CommentTextMaxLength, MinimumLength = CommentTextMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Text")]
        public string CommentText { get; set; } = null!;
    }
}
