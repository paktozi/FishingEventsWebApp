using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models;
using FishingEventsApp.Core.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface ILocationService
    {
        Task AddLocationAsync(LocationAddModel model);
        Task EditLocationAsync(LocationEditModel model, Location locationToEdit);
        Task<Location> FindLocationAsync(int id);
        Task<IEnumerable<FishingLocationModel>> GetAllLocationsAsync();
        Task<LocationEditModel> GetLocationToEdit(int id);
    }
}
