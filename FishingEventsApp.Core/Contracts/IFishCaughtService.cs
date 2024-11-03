using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsApp.Core.Models.SpeciesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface IFishCaughtService
    {
        Task AddFishAsync(FishCaughtAddModel model);
        Task<IEnumerable<SpeciesCaughtModel>> GetListSpeciesAsync();
        Task<ICollection<FishCaughtAllModel>> GetMyCaughtsAsync(string userId, int id);
    }
}
