namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingLocationModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Elevation { get; set; } = string.Empty;

        public string FishingType { get; set; } = string.Empty;

        public string? LocationImageUrl { get; set; }
    }
}
