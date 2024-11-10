using FishingEventsApp.Core.Models.ApplicationUserModels;

namespace FishingEventsApp.Core.Contracts
{
    public interface IApplicationUserService
    {
        Task<ICollection<ApplicationUserAllModel>> GetAllAsync();

        Task<ApplicationUserDetailsModel> GetDetailsAsync(string id);
    }
}
