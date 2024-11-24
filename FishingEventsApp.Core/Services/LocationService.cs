using FishingEvents.Infrastructure.Data.Models;
using FishingEvents.Infrastructure.Data.Models.WeatherModels;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.LocationModels;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FishingEventsApp.Core.Services
{
    public class LocationService(FishingEventsDbContext context, WeatherService weatherService) : ILocationService
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

        public async Task<IEnumerable<FishingLocationModel>> GetAllLocationsAsync(string? locationName)
        {
            IQueryable<Location> query = context.Locations;

            if (!string.IsNullOrEmpty(locationName))
            {
                query = query.Where(l => l.Name.Contains(locationName));
            }

            var model = await query
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

            foreach (var location in model)
            {
                try
                {
                    Weather weatherData = await weatherService.GetWeatherAsync(location.Name);
                    location.CurrentTemperature = weatherData.Conditions.Temp.ToString();
                    location.WeatherIcon = weatherData.Conditions.Icon;
                }
                catch (Exception ex)
                {
                    location.CurrentTemperature = "N/A";
                    location.WeatherIcon = "na";
                }
            }

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
