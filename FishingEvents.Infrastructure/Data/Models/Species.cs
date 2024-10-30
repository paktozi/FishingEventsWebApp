using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FishCaughtSpeciesNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(FishSpeciesDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpeciesHabitatNameMaxLength)]
        public string HabitatName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpeciesFishBaitMaxLength)]
        public string FishBait { get; set; } = string.Empty;

        public string? FishImageUrl { get; set; } = string.Empty;

        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();
    }
}