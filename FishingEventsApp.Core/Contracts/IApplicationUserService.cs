using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Models.ApplicationUserModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Contracts
{
    public interface IApplicationUserService
    {
        //Task<ApplicationUser?> GetUserByIdAsync(string userId);
        //Task<ApplicationUser?> GetUserWithParticipantByIdAsync(string userId);
        //Task<IdentityResult> CreateUserWithParticipantAsync(ApplicationUser user, string password, string participantFirstName, string participantLastName);
        //Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);
        //Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        //Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        //Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        //Task<SignInResult> SignInUserAsync(string email, string password, bool rememberMe);
        //Task SignOutUserAsync();
        Task<ICollection<ApplicationUserAllModel>> GetAllAsync();
        Task<ApplicationUserDetailsModel> GetDetailsAsync(string id);
    }
}
