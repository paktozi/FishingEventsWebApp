﻿using FishingEventsApp.Core.Models.SpeciesModels;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.FishCaughtModels
{
    public class FishCaughtEditModel
    {
        [Required]
        public int FishingEventId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int SpeciesId { get; set; }

        [Required]
        [Range(FishCaughtWeightMinRange, FishCaughtWeightMaxRange)]
        public double Weight { get; set; }

        [Required]
        [Range(FishCaughtLengthMinRange, FishCaughtLengthMaxRange)]
        public double Length { get; set; }

        [Display(Name = "Caught Image Url")]
        public string? CaughtImageUrl { get; set; }

        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$", ErrorMessage = DateErrorMessage)]
        [Required]
        [Display(Name = "Date Caught")]
        public string DateCaught { get; set; } = string.Empty;

        public IEnumerable<SpeciesCaughtModel> ListSpecies { get; set; } = new List<SpeciesCaughtModel>();
    }
}
