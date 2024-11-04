﻿using FishingEventsApp.Core.Models.SpeciesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models.FishCaughtModels
{
    public class FishCaughtAddModel
    {
        [Required]
        public int FishingEventId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int SpeciesId { get; set; }

        [Required]
        [Range(FishCaughtWeightMinRange, FishCaughtWeightMaxRange)]
        public double Weight { get; set; }

        [Required]
        [Range(FishCaughtLengthMinRange, FishCaughtLengthMaxRange)]
        public double Length { get; set; }

        public string? CaughtImageUrl { get; set; }

        [Required]
        public string DateCaught { get; set; } = string.Empty;

        public IEnumerable<SpeciesCaughtModel> ListSpecies { get; set; } = new List<SpeciesCaughtModel>();

    }
}