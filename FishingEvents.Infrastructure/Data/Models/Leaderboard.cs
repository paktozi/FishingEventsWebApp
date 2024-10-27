using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Leaderboard
    {
        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }
        public FishingEvent FishingEvent { get; set; }

        [ForeignKey(nameof(Participant))]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public double TotalWeightCaught { get; set; }
        public int Rank { get; set; }
    }
}
