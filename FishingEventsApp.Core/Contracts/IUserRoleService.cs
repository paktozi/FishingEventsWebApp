using FishingEvents.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface IUserRoleService
    {
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<List<string>> GetRolesAsync();
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<List<ApplicationUser>> GetUsersNotInRoleAsync(string role);
        Task<List<ApplicationUser>> GetUsersInRoleAsync(string role);

    }
}
