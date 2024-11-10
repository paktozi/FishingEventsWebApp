using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.EventsModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface IFishingEventService
    {
        Task<IEnumerable<FishingEventALLModel>> GetAllEventsAsync(string? userId, string? eventName);
        Task<ICollection<FishingLocationModel>?> GetLocationListAsync();
        Task AddFishingEventAsync(FishingEventAddModel model, string? userId);

        Task<FishingEvent> FindEventAsync(int id);

        Task JoinEventAsync(int id, string? userId);

        Task LeaveAsync(FishingEvent model, string? userId);

        Task DeleteEventAsync(FishingEvent entity);

        Task<FishingEventDetailModel> GetEventDetailsAsync(int id, string? userId);

        Task<FishingEventEditModel> GetEventToEditAsync(int id);

        Task EditEventAsync(FishingEventEditModel model, FishingEvent fishEvent);
        Task<IEnumerable<FishingEventAllParticipants>> GetAllParticipant(int id);
    }
}
