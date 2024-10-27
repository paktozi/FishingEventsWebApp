using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class EventParticipant
    {
        [Required]
        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }

        [Required]
        public FishingEvent FishingEvent { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Participant))]
        public int ParticipantId { get; set; }

        [Required]
        public Participant Participant { get; set; } = null!;
    }
}
