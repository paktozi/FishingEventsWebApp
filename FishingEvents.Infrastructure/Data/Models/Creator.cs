using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        // Relationship with ApplicationUser
        public IdentityUser User { get; set; }

        // Relationship with FishingEvent: a creator can create multiple events
        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();
    }
}
