using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(ParticipantNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
        public ICollection<FishCaught> FishCaught { get; set; } = new List<FishCaught>();
        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();
    }
}
