using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.FishCaughtModels;

namespace FishingEventsApp.Core.Models.ApplicationUserModels
{
    public class ApplicationUserDetailsModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public ICollection<FishCaughtAllModel> FishCaughtsList { get; set; } = new List<FishCaughtAllModel>();
        public ICollection<FishingEventALLModel> FishingEventsList { get; set; } = new List<FishingEventALLModel>();
    }
}
