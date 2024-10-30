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
        public int Id { get; set; }

        [Required, MaxLength(FishingEventNameMaxLength)]
        public string EventName { get; set; } = string.Empty;

        [Required, MaxLength(FishingEventDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; } = null!;

        public string? EventImageUrl { get; set; }


        [Required]
        [ForeignKey(nameof(Organizer))]
        [Comment("Foreign key for the organizer of the event")]
        public string OrganizerId { get; set; } = string.Empty;


        public ApplicationUser Organizer { get; set; } = null!;

        [Required]
        public bool IsCompleted { get; set; }


        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();

        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }

}
