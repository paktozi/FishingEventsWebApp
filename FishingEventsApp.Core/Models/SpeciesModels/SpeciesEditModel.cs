using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.SpeciesModels
{
    public class SpeciesEditModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesNameMaxLength, MinimumLength = SpeciesNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(FishSpeciesDescriptionMaxLength, MinimumLength = FishSpeciesDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesHabitatNameMaxLength, MinimumLength = SpeciesHabitatNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string HabitatName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(SpeciesFishBaitMaxLength, MinimumLength = SpeciesFishBaitMinLength, ErrorMessage = LengthErrorMessage)]
        public string FishBait { get; set; } = string.Empty;

        public string? FishImageUrl { get; set; } = string.Empty;
    }
}
