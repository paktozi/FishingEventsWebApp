using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.SpeciesModels
{
    public class SpeciesEditModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesNameMaxLength, MinimumLength = SpeciesNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Fish Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(FishSpeciesDescriptionMaxLength, MinimumLength = FishSpeciesDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesHabitatNameMaxLength, MinimumLength = SpeciesHabitatNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Habitat Name")]
        public string HabitatName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesFishBaitMaxLength, MinimumLength = SpeciesFishBaitMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Fish Bait")]
        public string FishBait { get; set; } = string.Empty;

        [Display(Name = "Fish Image Url")]
        public string? FishImageUrl { get; set; } = string.Empty;
    }
}
