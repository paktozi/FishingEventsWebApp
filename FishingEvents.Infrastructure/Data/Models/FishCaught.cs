using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class FishCaught
    {
        [Key]
        [Comment("Primary key identifier for FishCaught entry")]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(FishingEvent))]
        [Comment("Foreign key referencing the associated FishingEvent")]
        public int FishingEventId { get; set; }

        [Comment("Navigation property to the FishingEvent entity")]
        public FishingEvent FishingEvent { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Foreign key referencing the User who caught the fish")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Navigation property to the User who caught the fish")]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Species))]
        [Comment("Foreign key referencing the Species of the fish caught")]
        public int SpeciesId { get; set; }

        [Comment("Navigation property to the Species of the fish caught")]
        public Species Species { get; set; } = null!;


        [Required]
        [Comment("Weight of the fish caught in the specified measurement unit")]
        public double Weight { get; set; }

        [Required]
        [Comment("Length of the fish caught in the specified measurement unit")]
        public double Length { get; set; }

        [Comment("URL of the image showing the caught fish (optional)")]
        public string? CaughtImageUrl { get; set; }

        [Required]
        [Comment("Date and time when the fish was caught")]
        public DateTime DateCaught { get; set; }
    }
}
