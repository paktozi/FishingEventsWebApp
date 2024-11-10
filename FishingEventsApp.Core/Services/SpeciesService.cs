using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.SpeciesModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Core.Services
{
    public class SpeciesService(FishingEventsDbContext context) : ISpeciesService
    {
        public async Task AddFishAsync(SpeciesAddModel model)
        {
            Species newSpecies = new Species()
            {
                Name = model.Name,
                Description = model.Description,
                HabitatName = model.HabitatName,
                FishBait = model.FishBait,
                FishImageUrl = model.FishImageUrl,
            };
            await context.Species.AddAsync(newSpecies);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFishAsync(Species modelToDelete)
        {
            context.Species.Remove(modelToDelete);
            await context.SaveChangesAsync();
        }

        public async Task EditSpeciesAsync(SpeciesEditModel model, Species speciesToEdit)
        {
            speciesToEdit.Name = model.Name;
            speciesToEdit.Description = model.Description;
            speciesToEdit.HabitatName = model.HabitatName;
            speciesToEdit.FishBait = model.FishBait;
            speciesToEdit.FishImageUrl = model.FishImageUrl;
            await context.SaveChangesAsync();
        }

        public async Task<Species> FindSpeciesAsync(int id)
        {
            return await context.Species.FindAsync(id);
        }

        public async Task<IEnumerable<SpeciesAllModel>> GetAllSpeciesAsync()
        {
            var allSpecies = await context.Species
                 .Select(s => new SpeciesAllModel()
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Description = s.Description,
                     HabitatName = s.HabitatName,
                     FishBait = s.FishBait,
                     FishImageUrl = s.FishImageUrl,
                 })
                 .AsNoTracking()
                 .ToListAsync();
            return allSpecies;
        }

        public async Task<SpeciesEditModel> GetSpeciesToEdit(int id)
        {
            var speciesToEdit = await context.Species
                .Where(s => s.Id == id)
                .Select(s => new SpeciesEditModel()
                {
                    Name = s.Name,
                    Description = s.Description,
                    HabitatName = s.HabitatName,
                    FishBait = s.FishBait,
                    FishImageUrl = s.FishImageUrl,
                })
                .FirstOrDefaultAsync();
            return speciesToEdit;
        }
    }
}
