using FishingEventsApp.Core.Models.FishCaughtModels;

namespace FishingEventsApp.Core.Models.EventsModels
{
    public class FishingEventAllParticipants
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public int EventId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<FishCaughtAllModel> FishCaughtsList { get; set; } = new List<FishCaughtAllModel>();
    }
}
