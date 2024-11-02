using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Models.SpeciesModels
{
    public class SpeciesAllModel
    {
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;


        public string HabitatName { get; set; } = string.Empty;


        public string FishBait { get; set; } = string.Empty;

        public string? FishImageUrl { get; set; } = string.Empty;
    }
}
