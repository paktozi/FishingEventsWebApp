using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        // FishCaught relationship: a participant can have multiple fish caught records
        public ICollection<FishCaught> FishCaughtRecords { get; set; } = new List<FishCaught>();

        // Leaderboard relationship: participant can be on multiple leaderboards for various events
        public ICollection<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();
    }
}