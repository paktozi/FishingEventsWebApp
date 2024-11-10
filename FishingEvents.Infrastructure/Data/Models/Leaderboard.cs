using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class LeaderBoard
    {
        [ForeignKey(nameof(FishingEvent))]
        [Comment("Foreign key linking to the associated FishingEvent")]
        public int FishingEventId { get; set; }

        [Comment("Navigation property to the FishingEvent this leaderboard entry is associated with")]
        public FishingEvent FishingEvent { get; set; } = null!;

        [ForeignKey(nameof(User))]
        [Comment("Foreign key linking to the participating user")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the ApplicationUser (participant) this entry belongs to")]
        public ApplicationUser User { get; set; } = null!;

        [Comment("Total weight of all fish caught by the user during the event")]
        public double TotalWeight { get; set; }

        [Comment("Total number of fish caught by the user during the event")]
        public int TotalFishCaught { get; set; }
    }
}
