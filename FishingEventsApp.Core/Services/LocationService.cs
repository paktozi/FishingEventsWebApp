using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.LocationModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Core.Services
{
    public class LocationService(FishingEventsDbContext context) : ILocationService
    {
        public async Task AddLocationAsync(LocationAddModel model)
        {
            Location location = new Location()
            {
                Name = model.Name,
                Elevation = model.Elevation,
                FishingType = model.FishingType,
                LocationImageUrl = model.LocationImageUrl
            };
            await context.Locations.AddAsync(location);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLocationAsync(Location entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditLocationAsync(LocationEditModel model, Location locationToEdit)
        {
            locationToEdit.Name = model.Name;
            locationToEdit.Elevation = model.Elevation;
            locationToEdit.FishingType = model.FishingType;
            locationToEdit.LocationImageUrl = model.LocationImageUrl;
            await context.SaveChangesAsync();
        }

        public async Task<Location> FindLocationAsync(int id)
        {
            return await context.Locations.FindAsync(id);
        }

        public async Task<IEnumerable<FishingLocationModel>> GetAllLocationsAsync()
        {
            var model = await context.Locations
                .Select(l => new FishingLocationModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Elevation = l.Elevation,
                    FishingType = l.FishingType,
                    LocationImageUrl = l.LocationImageUrl,
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }

        public async Task<LocationEditModel> GetLocationToEdit(int id)
        {
            var locationToEdit = await context.Locations
                .Where(l => l.Id == id)
                .Select(l => new LocationEditModel()
                {
                    Name = l.Name,
                    Elevation = l.Elevation,
                    FishingType = l.FishingType,
                    LocationImageUrl = l.LocationImageUrl,
                }).FirstOrDefaultAsync();
            return locationToEdit;
        }
    }
}
