using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(FishingEvent))]
        [Comment("Foreign key referencing the associated FishingEvent")]
        public int FishingEventId { get; set; }

        [Comment("Navigation property to the FishingEvent the user is participating in")]
        public FishingEvent FishingEvent { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Foreign key referencing the participating user")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the user participating in the event")]
        public ApplicationUser User { get; set; } = null!;
    }
}
