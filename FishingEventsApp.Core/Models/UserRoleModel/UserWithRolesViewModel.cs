namespace FishingEventsApp.Core.Models.UserRoleModel
{
    public class UserWithRolesViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = string.Empty;
        public List<string>? Roles { get; set; }
    }
}
