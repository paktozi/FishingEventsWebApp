using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class LeaderBoard
    {

        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }

        public FishingEvent FishingEvent { get; set; } = null!;

        [ForeignKey(nameof(Participant))]
        public int ParticipantId { get; set; }

        public Participant Participant { get; set; } = null!;

        public double TotalWeight { get; set; }

        public int TotalFishCaught { get; set; }

    }
}
