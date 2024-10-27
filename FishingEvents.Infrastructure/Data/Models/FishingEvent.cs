using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{

    public class FishingEvent
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string EventName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public IdentityUser Creator { get; set; }

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
        public ICollection<FishCaught> FishCaught { get; set; } = new List<FishCaught>();
        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }

}
