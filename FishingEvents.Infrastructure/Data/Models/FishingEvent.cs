using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class FishingEvent
    {
        [Key]
        [Comment("Primary key identifier for the FishingEvent")]
        public int Id { get; set; }

        [Required, MaxLength(FishingEventNameMaxLength)]
        [Comment("Name of the fishing event")]
        public string EventName { get; set; } = string.Empty;

        [Comment("Description of the fishing event")]
        [Required, MaxLength(FishingEventDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Date and time when the event starts")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Date and time when the event ends")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Foreign key referencing the event location")]
        public int LocationId { get; set; }

        [Comment("Navigation property to the Location where the event takes place")]
        public Location Location { get; set; } = null!;

        [Comment("URL of an image representing the event (optional)")]
        public string? EventImageUrl { get; set; }


        [ForeignKey(nameof(Organizer))]
        [Comment("Foreign key referencing the Organizer of the event")]
        public string? OrganizerId { get; set; }  // todo make it nullable

        [Comment("Navigation property to the Organizer (user) of the event")]
        public ApplicationUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Indicates whether the event has been completed")]
        public bool IsCompleted { get; set; }

        [Comment("Collection of participants in the event")]
        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

        [Comment("Collection of fish caught during the event")]
        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();

        [Comment("Collection of comments for fishing events")]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
