using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Species
    {
        [Key]
        [Comment("Primary key identifier for the species")]
        public int Id { get; set; }

        [Required]
        [MaxLength(FishCaughtSpeciesNameMaxLength)]
        [Comment("Name of the species")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(FishSpeciesDescriptionMaxLength)]
        [Comment("Description of the species")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpeciesHabitatNameMaxLength)]
        [Comment("The habitat name where the species is typically found")]
        public string HabitatName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpeciesFishBaitMaxLength)]
        [Comment("The type of bait typically used to catch this species")]
        public string FishBait { get; set; } = string.Empty;

        [Comment("Optional URL of an image representing the species")]
        public string? FishImageUrl { get; set; } = string.Empty;

        [Comment("Collection of FishCaught records related to this species")]
        public ICollection<FishCaught> FishCaughts { get; set; } = new List<FishCaught>();
    }
}