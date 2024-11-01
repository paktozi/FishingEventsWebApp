using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required, MaxLength(LocationNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(LocationElevationMaxLength)]
        public string Elevation { get; set; } = string.Empty;

        [Required, MaxLength(LocationFishingTypeMaxLength)]
        public string FishingType { get; set; } = string.Empty;

        public string? LocationImageUrl { get; set; }

        //ToDo add public int SpeciesId{get;set;}   public Species Species{get;set;}


        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();
    }
}