using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class FishingEvent
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(FishingEventNameMaxLength)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(FishingEventDescriptionMaxLength)]
        public required string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        [Required]
        public Location Location { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; } = null!;
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        public bool IsCompleted { get; set; }
    }
}
