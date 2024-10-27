using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEvents.Infrastructure.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Altitude { get; set; }
        public string FishingMethod { get; set; }

        public ICollection<FishingEvent> FishingEvents { get; set; } = new List<FishingEvent>();
    }
}