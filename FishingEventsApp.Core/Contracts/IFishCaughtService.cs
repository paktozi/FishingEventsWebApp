using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsApp.Core.Models.SpeciesModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface IFishCaughtService
    {
        Task AddFishAsync(FishCaughtAddModel model);
        Task DeleteCaughtAsync(FishCaught entity);
        Task EditCaughtAsync(FishCaughtEditModel model, FishCaught fishCaught);
        Task<FishCaught> FindCaughtAsync(int id);
        Task<FishCaught> FindCaughtToDeleteAsync(int id);
        Task<FishCaughtEditModel> GetCaughtToEditAsync(int id);
        Task<IEnumerable<SpeciesCaughtModel>> GetListSpeciesAsync();
        Task<ICollection<FishCaughtAllModel>> GetMyCaughtsAsync(string userId, int id);
    }
}
