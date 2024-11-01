﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.LocationModels
{
    public class LocationAddModel
    {

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationElevationMaxLength, MinimumLength = LocationElevationMinLength, ErrorMessage = LengthErrorMessage)]
        public string Elevation { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(LocationFishingTypeMaxLength, MinimumLength = LocationFishingTypeMinLength, ErrorMessage = LengthErrorMessage)]
        public string FishingType { get; set; } = string.Empty;

        public string? LocationImageUrl { get; set; }

        //ToDo add public int SpeciesId{get;set;}   public Species Species{get;set;}

    }
}