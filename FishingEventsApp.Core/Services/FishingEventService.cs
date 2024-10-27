using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
using FishingEventsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
