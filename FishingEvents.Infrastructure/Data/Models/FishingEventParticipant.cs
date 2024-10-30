using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }

        public FishingEvent FishingEvent { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;
    }
}
