﻿using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.EventsModels;
using FishingEventsApp.Core.Models.FishCaughtModels;
using FishingEventsApp.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Globalization;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Services
{
    public class FishingEventService(FishingEventsDbContext context, UserManager<ApplicationUser> userManager) : IFishingEventService
    {
        public async Task<IEnumerable<FishingEventALLModel>> GetAllEventsAsync(string? userId)
        {
            var model = await context.FishingEvents
                 .Where(e => e.IsCompleted == false)
                 .Select(e => new FishingEventALLModel()
                 {
                     Id = e.Id,
                     EventName = e.EventName,
                     EventImageUrl = e.EventImageUrl,
                     StartDate = e.StartDate.ToString(DateFormat),
                     EndDate = e.EndDate.ToString(DateFormat),
                     LocationName = e.Location.Name,
                     Organizer = e.Organizer.FirstName,
                     IsOrganizer = e.OrganizerId == userId,
                     IsJoined = e.EventParticipants.Any(ep => ep.FishingEventId == e.Id && ep.UserId == userId),
                     Mail = e.Organizer.Email,
                     //FishCaughtList = e.FishCaughts
                     //.Where(f => f.FishingEventId == f.Id)
                     //.Select(f => new FishCaughtAllModel()
                     //{
                     //    FishingEventName = f.FishingEvent.EventName,
                     //    Species = f.Species.Name,
                     //    DateCaught = f.DateCaught.ToString(DateFormat),
                     //    CaughtImageUrl = f.CaughtImageUrl,
                     //    Weight = f.Weight,
                     //    Length = f.Length
                     //})
                     //.ToList()
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
                   Elevation = e.Elevation,
                   FishingType = e.FishingType,
                   LocationImageUrl = e.LocationImageUrl,
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
                     Elevation = e.Elevation,
                     FishingType = e.FishingType,
                     LocationImageUrl = e.LocationImageUrl,
                 })
                 .AsNoTracking()
                 .ToListAsync();
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
            entity.EventName = model.EventName;
            entity.Description = model.Description;
            entity.StartDate = parseStartDate;
            entity.EndDate = parseEndDate;
            entity.LocationId = model.LocationId;
            entity.EventImageUrl = model.EventImageUrl;
            entity.OrganizerId = userId;
            await context.FishingEvents.AddAsync(entity);
            await context.SaveChangesAsync();
        }


        public async Task<FishingEvent> FindEventAsync(int id)
        {
            return await context.FishingEvents.FindAsync(id);//FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task JoinEventAsync(int id, string? userId)
        {
            bool isAlreadyAdded = await context.EventParticipants.AnyAsync(ep => ep.FishingEventId == id && ep.UserId == userId);

            if (!isAlreadyAdded)
            {
                EventParticipant model = new EventParticipant()
                {
                    FishingEventId = id,
                    UserId = userId
                };
                await context.EventParticipants.AddAsync(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task LeaveAsync(FishingEvent model, string? userId)
        {
            var entity = await context.EventParticipants.FirstOrDefaultAsync(ep => ep.FishingEventId == model.Id && ep.UserId == userId);
            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEventAsync(FishingEvent entity)
        {
            entity.IsCompleted = true;
            await context.SaveChangesAsync();
        }

        public async Task<FishingEventDetailModel> GetEventDetailsAsync(int id)
        {
            FishingEventDetailModel? model = await context.FishingEvents
                .Where(f => f.Id == id)
                .Include(f => f.Location)
                .Select(f => new FishingEventDetailModel()
                {
                    Id = f.Id,
                    EventName = f.EventName,
                    Description = f.Description,
                    StartDate = f.StartDate.ToString(DateFormat),
                    EndDate = f.EndDate.ToString(DateFormat),
                    LocationName = f.Location.Name,
                    Organizer = f.Organizer.FirstName,
                    ImageUrl = f.Location.LocationImageUrl ?? string.Empty,
                    FishingType = f.Location.FishingType
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task<FishingEventEditModel> GetEventToEditAsync(int id)
        {
            var location = await GetLocation();

            var model = await context.FishingEvents
                .Where(f => f.Id == id)
                .Select(f => new FishingEventEditModel()
                {
                    EventName = f.EventName,
                    Description = f.Description,
                    StartDate = f.StartDate.ToString(DateFormat),
                    EndDate = f.EndDate.ToString(DateFormat),
                    LocationId = f.Location.Id,
                    Locations = location,
                    EventImageUrl = f.EventImageUrl,
                    OrganizerId = f.OrganizerId
                })
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task EditEventAsync(FishingEventEditModel model, FishingEvent fishEvent)
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

            fishEvent.EventName = model.EventName;
            fishEvent.Description = model.Description;
            fishEvent.StartDate = parseStartDate;
            fishEvent.EndDate = parseEndDate;
            fishEvent.LocationId = model.LocationId;
            fishEvent.EventImageUrl = model.EventImageUrl;
            await context.SaveChangesAsync();
        }
    }
}
