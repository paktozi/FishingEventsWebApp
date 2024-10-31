using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface IFishingEventService
    {

        Task<IEnumerable<FishingEventALLModel>> GetAllEventsAsync(string? userId);
        Task<ICollection<FishingLocationModel>?> GetLocationListAsync();
        Task AddFishingEventAsync(FishingEventAddModel model, string? userId);

        //Task<FishingEvent> GetEventByIdAsync(int id);

        //Task JoinEventAsync(int id, string? userId);
    }
}
