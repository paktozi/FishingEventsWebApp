namespace FishingEventsApp.Core.Models.FishCaughtModels
{
    public class FishCaughtAllModel
    {
        public int Id { get; set; }

        public int FishingEventId { get; set; }

        public string FishingEventName { get; set; } = string.Empty;

        public string? UserId { get; set; }

        public string Species { get; set; } = string.Empty;

        public double Weight { get; set; }

        public double Length { get; set; }

        public string? CaughtImageUrl { get; set; }

        public string DateCaught { get; set; } = string.Empty;
    }
}
