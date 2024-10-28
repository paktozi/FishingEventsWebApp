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
        public int LocationId { get; set; }

        public Location Location { get; set; } = null!;

        [Required]
        public int OrganiserId { get; set; }

        [ForeignKey(nameof(OrganiserId))]
        public Organiser Organiser { get; set; } = null!;

        public bool IsCompleted { get; set; }

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
        public ICollection<FishCaught> FishCaught { get; set; } = new List<FishCaught>();
        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }

}
