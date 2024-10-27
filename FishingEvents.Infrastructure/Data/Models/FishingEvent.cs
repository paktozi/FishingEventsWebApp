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
        public string Title { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key and relationship to Creator
        [Required]
        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        public Creator Creator { get; set; }

        // Foreign Key and relationship to Location
        [Required]
        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        // Navigation property for participants in this event
        public ICollection<FishingEventParticipant> Participants { get; set; } = new List<FishingEventParticipant>();

        // Navigation property for leaderboard entries
        public ICollection<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();

        // Navigation property for fish caught in this event
        public ICollection<FishCaught> FishCaughtRecords { get; set; } = new List<FishCaught>();
    }

}
