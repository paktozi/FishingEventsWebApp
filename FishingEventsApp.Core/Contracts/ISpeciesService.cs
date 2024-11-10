using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.SpeciesModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface ISpeciesService
    {
        Task AddFishAsync(SpeciesAddModel model);
        Task DeleteFishAsync(Species modelToDelete);
        Task EditSpeciesAsync(SpeciesEditModel model, Species speciesToEdit);
        Task<Species> FindSpeciesAsync(int id);
        Task<IEnumerable<SpeciesAllModel>> GetAllSpeciesAsync();
        Task<SpeciesEditModel> GetSpeciesToEdit(int id);
    }
}
