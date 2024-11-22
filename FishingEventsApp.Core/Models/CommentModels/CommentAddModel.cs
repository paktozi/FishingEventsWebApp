using FishingEvents.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
