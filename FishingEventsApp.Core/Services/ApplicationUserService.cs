using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using FishingEventsApp.Core.Models.FishCaughtModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FishingEventsApp.Common.ValidationConstants;

namespace FishingEventsApp.Core.Services
{
    public class ApplicationUserService(UserManager<ApplicationUser> userManager) : IApplicationUserService
    {

        public async Task<ICollection<ApplicationUserAllModel>> GetAllAsync()
        {
            var model = await userManager.Users
                .Select(u => new ApplicationUserAllModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }

        public async Task<ApplicationUserDetailsModel> GetDetailsAsync(string id)
        {
            var model = await userManager.Users
                 .Where(u => u.Id == id)
                 .Select(u => new ApplicationUserDetailsModel()
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     FishCaughtsList = u.FishCaughts
                     .Select(fc => new FishCaughtAllModel()
                     {
                         CaughtImageUrl = fc.CaughtImageUrl,
                         FishingEventName = fc.FishingEvent.EventName,
                         Species = fc.Species.Name,
                         Weight = fc.Weight,
                         Length = fc.Length,
                         DateCaught = fc.DateCaught.ToString(DateFormat),
                     })
                     .ToList()
                 })
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
            return model;
        }



    }
}
