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
        public async Task<ICollection<ApplicationUserAllModel>> GetAllAsync(string? userName)
        {
            var query = userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(userName))
            {
                query = query.Where(u => u.FirstName.Contains(userName)
                                      || u.LastName.Contains(userName)
                                      || u.UserName.Contains(userName));
            }

            var users = await query
                .Select(u => new ApplicationUserAllModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName
                })
                .AsNoTracking()
                .ToListAsync();

            var usersWithoutAdminRole = new List<ApplicationUserAllModel>();

            foreach (var user in users)
            {
                var applicationUser = await userManager.FindByIdAsync(user.Id);
                if (!await userManager.IsInRoleAsync(applicationUser, AdminRole) && !await userManager.IsInRoleAsync(applicationUser, GlobalAdminRole))
                {
                    usersWithoutAdminRole.Add(user);
                }
            }
            return usersWithoutAdminRole;
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
                         FishingEventStatus = fc.FishingEvent.IsCompleted ? EventStatusCompleted : EventStatusActive,
                         Species = fc.Species.Name,
                         Weight = fc.Weight,
                         Length = fc.Length,
                         DateCaught = fc.DateCaught.ToString(DateFormat),
                     })
                     .OrderByDescending(w => w.Weight)
                     .ToList()
                 })
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
            return model;
        }
    }
}