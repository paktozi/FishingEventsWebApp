using FishingEventsApp.Core.Models.UserRoleModel;

namespace FishingEventsApp.Core.Contracts
{
    public interface IUserRoleService
    {
        Task<List<UserWithRolesViewModel>> GetUsersWithRolesAsync();
        Task<bool> AddRoleToUserAsync(string userId, string roleName);
        Task<bool> RemoveRoleFromUserAsync(string userId, string roleName);
    }
}
