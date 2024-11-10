using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.LocationModels
{
    public class LocationEditModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Location name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationElevationMaxLength, MinimumLength = LocationElevationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Elevation { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationFishingTypeMaxLength, MinimumLength = LocationFishingTypeMinLength, ErrorMessage = LengthErrorMessage)]
        [Display(Name = "Fishing Type")]
        public string FishingType { get; set; } = string.Empty;

        [Display(Name = "Location Image Url")]
        public string? LocationImageUrl { get; set; }
    }
}
