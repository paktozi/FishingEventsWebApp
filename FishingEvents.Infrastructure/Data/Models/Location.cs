using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Location
    {
        [Key]
        [Comment("Location Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Altitude { get; set; } = string.Empty;


        public string? ImageUrl { get; set; }

        [Required]
        public string FishingType { get; set; } = string.Empty;
    }
}