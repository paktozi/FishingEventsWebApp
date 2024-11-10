namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventDetailModel
    {
        public int Id { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public string LocationName { get; set; } = string.Empty;

        public string Organizer { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string FishingType { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
