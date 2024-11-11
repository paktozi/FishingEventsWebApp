using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.LocationModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface ILocationService
    {
        Task AddLocationAsync(LocationAddModel model);
        Task DeleteLocationAsync(Location entity);
        Task EditLocationAsync(LocationEditModel model, Location locationToEdit);
        Task<Location> FindLocationAsync(int id);
        Task<IEnumerable<FishingLocationModel>> GetAllLocationsAsync(string? locationName);
        Task<LocationEditModel> GetLocationToEdit(int id);
    }
}
