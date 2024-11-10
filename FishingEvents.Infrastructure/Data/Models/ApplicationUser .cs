using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(UserFirstNameMaxLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(UserLastNameMaxLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = string.Empty;

        [Comment("Collection of fishing events organized by the user")]
        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();

        [Comment("Collection of events the user is a participant in")]
        public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();

        [Comment("Collection of leaderboards associated with the user's events")]
        public ICollection<LeaderBoard> LeaderBoards { get; set; } = new List<LeaderBoard>();

        [Comment("Collection of fish caught by the user in various events")]
        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();
    }
}
