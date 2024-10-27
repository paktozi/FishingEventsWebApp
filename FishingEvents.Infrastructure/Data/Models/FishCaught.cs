using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class FishCaught
    {
        public int Id { get; set; }

        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }

        public FishingEvent FishingEvent { get; set; }

        [ForeignKey(nameof(Participant))]
        public int ParticipantId { get; set; }

        public Participant Participant { get; set; }


        public string Species { get; set; }

        public double Weight { get; set; }

        public double Length { get; set; }

        public string? FishImageUrl { get; set; }

        public DateTime DateCaught { get; set; }
    }
}
