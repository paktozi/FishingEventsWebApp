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

        [Required]
        [MaxLength(FishingEventNameMaxLength)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        [MaxLength(FishingEventDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

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
        public string CreatorId { get; set; }

        [Required]
        public IdentityUser Creator { get; set; } = null!;

        [Required]
        public bool IsCompleted { get; set; }

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

        public ICollection<FishCaught> FishCaught { get; set; } = new List<FishCaught>();

        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }

}
