using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.SpeciesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
