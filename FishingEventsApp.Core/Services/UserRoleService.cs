using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Services
{
    public class UserRoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : IUserRoleService
    {


        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return userManager.Users.ToList();
        }

        public async Task<List<string>> GetRolesAsync()
        {
            return roleManager.Roles.Select(r => r.Name).ToList();
        }

        public async Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role)
        {
            var currentRoles = await userManager.GetRolesAsync(user);
            if (currentRoles.Contains(role))
            {
                return IdentityResult.Failed(new IdentityError { Description = "User is already assigned to this role." });
            }

            return await userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role)
        {
            var currentRoles = await userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(role))
            {
                return IdentityResult.Failed(new IdentityError { Description = "User is not in the specified role." });
            }

            return await userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task<List<ApplicationUser>> GetUsersNotInRoleAsync(string role)
        {
            var users = userManager.Users.ToList();
            var usersNotInRole = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (!await userManager.IsInRoleAsync(user, role))
                {
                    usersNotInRole.Add(user);
                }
            }

            return usersNotInRole;
        }

        public async Task<List<ApplicationUser>> GetUsersInRoleAsync(string role)
        {
            var users = userManager.Users.ToList();
            var usersInRole = new List<ApplicationUser>();

            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, role))
                {
                    usersInRole.Add(user);
                }
            }

            return usersInRole;
        }




    }
}

