using FishingEvents.Infrastructure.Data.Models;
using FishingEventsApp.Core.Contracts;
using FishingEventsApp.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly ApplicationDbContext _context;

        //public ApplicationUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _context = context;
        //}

        //public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        //{
        //    return await _userManager.FindByIdAsync(userId);
        //}

        //public async Task<ApplicationUser?> GetUserWithParticipantByIdAsync(string userId)
        //{
        //    return await _context.Users
        //        .Include(u => u.Participant)
        //        .FirstOrDefaultAsync(u => u.Id == userId);
        //}

        //public async Task<IdentityResult> CreateUserWithParticipantAsync(ApplicationUser user, string password, string participantFirstName, string participantLastName)
        //{
        //    // Create the ApplicationUser
        //    var result = await _userManager.CreateAsync(user, password);

        //    if (result.Succeeded)
        //    {
        //        // Create and associate Participant if user creation succeeded
        //        var participant = new Participant
        //        {
        //            UserId = user.Id,
        //            FirstName = participantFirstName,
        //            LastName = participantLastName,
        //        };

        //        _context.Participants.Add(participant);
        //        await _context.SaveChangesAsync();
        //    }

        //    return result;
        //}

        //public async Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role)
        //{
        //    return await _userManager.AddToRoleAsync(user, role);
        //}

        //public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        //{
        //    return await _userManager.GetRolesAsync(user);
        //}

        //public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        //{
        //    return await _userManager.UpdateAsync(user);
        //}

        //public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        //{
        //    var participant = await _context.Participants.FirstOrDefaultAsync(p => p.UserId == user.Id);

        //    if (participant != null)
        //    {
        //        _context.Participants.Remove(participant);
        //        await _context.SaveChangesAsync();
        //    }

        //    return await _userManager.DeleteAsync(user);
        //}

        //public async Task<SignInResult> SignInUserAsync(string email, string password, bool rememberMe)
        //{
        //    return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        //}

        //public async Task SignOutUserAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //}


    }
}
