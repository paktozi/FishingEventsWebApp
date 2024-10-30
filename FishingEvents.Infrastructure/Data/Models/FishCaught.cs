using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class FishCaught
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(FishingEvent))]
        public int FishingEventId { get; set; }

        public FishingEvent FishingEvent { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        [Required, MaxLength(FishCaughtSpeciesMaxLength)]
        public string Species { get; set; } = string.Empty;

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Length { get; set; }

        public string? FishImageUrl { get; set; }

        [Required]
        public DateTime DateCaught { get; set; }
    }

}
