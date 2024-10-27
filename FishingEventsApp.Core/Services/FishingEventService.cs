using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Web.Mvc;


using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Services
{
    public class FishingEventService(FishingEventsDbContext context) : IFishingEventService
    {
        public async Task<IEnumerable<FishingEventALLModel>> GetAllEventsAsync()
        {
            var model = await context.FishingEvents
                 .Where(e => e.IsCompleted == false)
                 .Select(e => new FishingEventALLModel()
                 {
                     Id = e.Id,
                     EventName = e.EventName,
                     StartDate = e.StartDate.ToString(DateFormat),
                     EndDate = e.EndDate.ToString(DateFormat),
                     LocationName = e.Location.Name,
                     Creator = e.Creator.UserName
                 })
                 .AsNoTracking()
                 .ToListAsync();
            return model;
        }


        public async Task<ICollection<FishingLocationModel>?> GetLocationListAsync()
        {
            var model = await context.Locations
               .Select(e => new FishingLocationModel()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Altitude = e.Altitude,
                   FishingType = e.FishingType
               })
               .AsNoTracking()
               .ToListAsync();
            return model;
        }
        async Task<ICollection<FishingLocationModel>?> IFishingEventService.GetLocationListAsync()
        {
            return await GetLocation();
        }





        public async Task AddFishingEventAsync(FishingEventAddModel model, string userId)
        {

            string startDate = $"{model.StartDate}";
            string endDate = $"{model.EndDate}";

            if (!DateTime.TryParseExact(startDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseStartDate))
            {
                throw new InvalidOperationException("Invalid date format.");
            }
            if (!DateTime.TryParseExact(endDate, DateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseEndDate))
            {
                throw new InvalidOperationException("Invalid date format.");
            }




            FishingEvent entity = new FishingEvent();
            entity.Id = model.Id;
            entity.EventName = model.EventName;
            entity.Description = model.Description;
            entity.StartDate = parseStartDate;
            entity.EndDate = parseEndDate;
            entity.LocationId = model.LocationId;
            entity.CreatorId = userId;
            await context.FishingEvents.AddAsync(entity);
            await context.SaveChangesAsync();
        }





        private async Task<ICollection<FishingLocationModel>> GetLocation()
        {
            return await context.Locations
                 .Select(e => new FishingLocationModel()
                 {
                     Id = e.Id,
                     Name = e.Name,
                     Altitude = e.Altitude,
                     FishingType = e.FishingType
                 })
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
