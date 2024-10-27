using Microsoft.AspNetCore.Identity;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation Property: one user can be associated with one creator profile
        public Creator? Creator { get; set; }

        // Navigation Property: one user can be a participant in multiple events
        public ICollection<FishingEventParticipant> FishingEventParticipations { get; set; } = new List<FishingEventParticipant>();
    }
}
