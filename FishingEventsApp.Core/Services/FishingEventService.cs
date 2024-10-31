using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models;
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
                     Mail = e.Organizer.Email
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
            entity.Id = model.Id;
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







        //public async Task<FishingEvent> GetEventByIdAsync(int id)
        //{
        //    return await context.FishingEvents.FirstOrDefaultAsync(f => f.Id == id);
        //}

        ////public Task GetJoinEvent(int id, string? userId)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public async Task JoinEventAsync(int id, string? userId)
        ////{

        ////    //var participantId = await context.Participants
        ////    //                          .Where(p => p.UserId == userId)
        ////    //                          .Select(p => p.Id)
        ////    //                          .FirstOrDefaultAsync();

        ////    //bool isAlreadyAdded = await context.EventParticipants.AnyAsync(ep => ep.FishingEventId == id && ep.ParticipantId == participantId);

        ////    //if (!isAlreadyAdded)
        ////    //{
        ////    //    EventParticipant model = new EventParticipant()
        ////    //    {
        ////    //        ParticipantId = participantId,
        ////    //        FishingEventId = id
        ////    //    };
        ////    //    await context.EventParticipants.AddAsync(model);
        ////    //    await context.SaveChangesAsync();
        ////    //}

        ////    if (userId == null)
        ////    {
        ////        throw new ArgumentNullException(nameof(userId), "User ID cannot be null.");
        ////    }

        ////    var participant = await context.Participants.SingleOrDefaultAsync(p => p.UserId == userId);

        ////    // Create participant if it doesn't exist
        ////    if (participant == null)
        ////    {
        ////        var user = await context.Users.FindAsync(userId);
        ////        if (user == null)
        ////        {
        ////            throw new Exception($"No user found with ID: {userId}");
        ////        }

        ////        participant = new Participant
        ////        {
        ////            UserId = userId,
        ////            User = user,
        ////            FirstName = user.FirstName // or any other property you wish to use
        ////        };

        ////        context.Participants.Add(participant);
        ////        await context.SaveChangesAsync();
        ////    }

        ////    // Check if participant is already part of the event
        ////    bool isAlreadyAdded = await context.EventParticipants.AnyAsync(ep => ep.FishingEventId == id && ep.ParticipantId == participant.Id);

        ////    if (!isAlreadyAdded)
        ////    {
        ////        var eventParticipant = new EventParticipant
        ////        {
        ////            ParticipantId = participant.Id,
        ////            FishingEventId = id
        ////        };

        ////        await context.EventParticipants.AddAsync(eventParticipant);
        ////        await context.SaveChangesAsync();
        ////    }
        ////}



    }
}
