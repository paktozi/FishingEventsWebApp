using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Core.Models.UserRoleModel;
using FishingEventsApp.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FishingEventsApp.Core.Services
{
    public class UserRoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, FishingEventsDbContext context) : IUserRoleService
    {
        public async Task<List<UserWithRolesViewModel>> GetUsersWithRolesAsync()
        {
            var users = await context.Users
        .Where(user => !context.UserRoles      // Exclude users with the GlobalAdmin role
            .Where(ur => ur.UserId == user.Id)
            .Join(context.Roles,
                  ur => ur.RoleId,
                  role => role.Id,
                  (ur, role) => role.Name)
            .Contains("GlobalAdmin"))

        .Select(user => new UserWithRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Roles = context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Join(context.Roles,
                      ur => ur.RoleId,
                      role => role.Id,
                      (ur, role) => role.Name)
                .ToList()
        })
        .OrderBy(n => n.UserName)
        .ToListAsync();

            return users;
        }

        public async Task<bool> AddRoleToUserAsync(string? userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return false;
            }

            var result = await userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> RemoveRoleFromUserAsync(string? userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<ApplicationUser> FindUserAsync(string? id)
        {
            return await context.Users.FirstAsync(u => u.Id == id);
        }

        public async Task DeleteUserAsync(ApplicationUser entity, string? userId, string? globalAdminId)
        {
            await context.EventParticipants.Where(ep => ep.UserId == userId).ExecuteDeleteAsync();
            await context.FishCaughts.Where(fc => fc.UserId == userId).ExecuteDeleteAsync();
            await context.UserRoles.Where(ur => ur.UserId == userId).ExecuteDeleteAsync();
            await context.Comments.Where(c => c.AuthorId == userId).ExecuteDeleteAsync();

            await context.FishingEvents
              .Where(f => f.OrganizerId == userId)
              .ExecuteUpdateAsync(setters => setters
             .SetProperty(e => e.OrganizerId, globalAdminId));  //The global admin takes over the organization of the event

            context.Users.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

