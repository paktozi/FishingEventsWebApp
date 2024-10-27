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
        Task<IEnumerable<FishingEventALLModel>> GetAllEventsAsync();
        Task<ICollection<FishingLocationModel>?> GetLocationListAsync();
    }
}
