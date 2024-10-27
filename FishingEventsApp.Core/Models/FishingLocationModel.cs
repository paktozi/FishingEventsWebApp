using System.ComponentModel.DataAnnotations;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Models
{
    public class FishingLocationModel
    {

        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Altitude { get; set; } = string.Empty;


        public string FishingType { get; set; } = string.Empty;
    }
}
