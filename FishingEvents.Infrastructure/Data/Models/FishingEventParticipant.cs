using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class EventParticipant
    {
        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }
        public FishingEvent FishingEvent { get; set; }

        [ForeignKey(nameof(Participant))]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }



}
