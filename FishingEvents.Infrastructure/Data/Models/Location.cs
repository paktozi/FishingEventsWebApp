using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Location
    {
        [Key]
        [Comment("Primary key identifier for the location")]
        public int Id { get; set; }

        [Required, MaxLength(LocationNameMaxLength)]
        [Comment("Name of the location")]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(LocationElevationMaxLength)]
        [Comment("Elevation of the location")]
        public string Elevation { get; set; } = string.Empty;

        [Required, MaxLength(LocationFishingTypeMaxLength)]
        [Comment("Type of fishing available at this location")]
        public string FishingType { get; set; } = string.Empty;

        [Comment("Optional URL of an image representing the location")]
        public string? LocationImageUrl { get; set; }

        [Comment("Collection of fishing events that take place at this location")]
        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();
    }
}